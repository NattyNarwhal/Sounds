#pragma once

#include "PP-UWP-Interop.h"

// TODO: upgrade toolchain and remove this so it'll work
// UWP requires a workaround that needs a Win10 UWP API to fix
#define WINDOWS_10_MEDIA_API 0

extern "C" {
// Use a saner subset of C++ compatible with C
#if 1
typedef void(*VoidFtnPtr)(void);

typedef struct {
	VoidFtnPtr Play;
	VoidFtnPtr Pause;
	VoidFtnPtr Stop;
	VoidFtnPtr Next;
	VoidFtnPtr Previous;
	VoidFtnPtr FastForward;
	VoidFtnPtr Rewind;
} UserEventCallback;

//! Track information structure to pass to API::NewTrack(). \n
//! Members can be null/zero if specific parts of the information are not available for the current track. \n
//! It is recommended to pass just title + artist + imgData/imgBytes; the rest isn't known to be used correctly.
typedef struct {
	const wchar_t * title;
	const wchar_t * artist;
	const wchar_t* albumArtist;
	const wchar_t* albumTitle;
	const void * imgData; size_t imgBytes;
	DWORD trackNumber, trackCount;
} TrackInfo;
#endif
}

namespace PP {
	//! A namespace containing our Universal Volume Control related definitions
	namespace UVC {
		//! Primary interface for interfacing with our Unviersal Volume Control wrapper. \n
		//! Call PP_UVC_Init() to instantiate. \n
		//! Currently there's no way to shut it down, as in majority of apps it will stay active until the end of the process lifetime.
		class __declspec(novtable) API {
		public:
			//! Call when playback has stopped / there is no track playing.
			virtual void Stopped() = 0;
			//! Call when either playback has advanced to another track, or when some part of currently playing track information has changed.
			virtual void NewTrack(const TrackInfo & info) = 0;
			//! Call to indicate paused/unpaused status.
			virtual void Paused(bool bPaused) = 0;

		private: API(const API &) = delete; void operator=(const API &) = delete;
		protected: API() {} ~API() {}
		};

		//! Prototype of PP_UVC_Init function, for people using LoadLibrary()/GetProcAddress().
		typedef API * (* Init_t)(UserEventCallback * cb);
	}
}

extern "C" {
	//! Main function for initializing our UVC wrapper. \n
	//! Should be only called once within a process lifetime. \n
	//! Takes a callback object to receive user events from UVC playback controls. \n
	//! Returns an object allowing the caller to pass playback status information to UVC.
	PP_UWP_INTEROP_API PP::UVC::API * PP_UVC_Init( UserEventCallback * cb );

	// Shims for C FFI
	// They're void* because of some godawful linking error

	PP_UWP_INTEROP_API void UVC_C_Stopped(PP::UVC::API * api);
	PP_UWP_INTEROP_API void UVC_C_NewTrack(PP::UVC::API * api, const TrackInfo & info);
	PP_UWP_INTEROP_API void UVC_C_Paused(PP::UVC::API * api, bool paused);
}

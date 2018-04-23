#pragma once

#ifndef PP_UWP_INTEROP_API
#ifndef PP_UWP_INTEROP_EXPORTS
#define PP_UWP_INTEROP_API __declspec(dllimport)
#else
#define PP_UWP_INTEROP_API __declspec(dllexport)
#endif
#endif

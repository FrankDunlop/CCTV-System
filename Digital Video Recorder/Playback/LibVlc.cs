﻿/*****************************************************************************    
                      (C) Copyright by Odysee
                                                                                  
Module   : LibVlc.cs
SCCS     : $Archive: $ $Revision:  $
Author   : Odysee
Date     : 10.11.2006
Last Change : $Date: $ $Author: $  
Description : 

Known problems :

Modification history :
     Date   | Usr.| Comment
   ---------+-----+----------------------------------------------------------    
            |     |
******************************************************************************/
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace DVR.LibVlc
{
    /****************************************************************************
    Class name     :  LibVlc
    Author         :  Odysee
    Date           :  22.12.2005
    Description    :  

    Known problems :

    Modification history : 

      Date   | Usr.| Comment 
    ---------+-----+----------------------------------------------------------
             |     | 
    ****************************************************************************/
    /// <summary>
    /// Class LibVlc
    /// </summary>
    public class Vlc : IDisposable
    {
        //---------------------------------------------------------------------
        // -- public enums
        #region public enums

        public enum Error
        {
            Success     = -0,
            NoMem       = -1,
            Thread      = -2,
            Timeout     = -3,

            NoMod       = -10,

            NoObj       = -20,
            BadObj      = -21,

            NoVar       = -30,
            BadVar      = -31,

            Exit        = -255,
            Generic     = -666,

            Execption   = -998,
            NoInit      = -999
        };

        enum Mode
        {
            Insert      = 0x01,
            Replace     = 0x02,
            Append      = 0x04,
            Go          = 0x08,
            CheckInsert = 0x10
        };

        enum Pos
        {
            End = -666
        };

        #endregion
        //---------------------------------------------------------------------

        //---------------------------------------------------------------------
        // -- public  structs
        #region public structs
        [StructLayout( LayoutKind.Explicit )]
        public struct vlc_value_t
        {
            [FieldOffset( 0 )]  public Int32   i_int;
            [FieldOffset( 0 )]  public Int32   b_bool;
            [FieldOffset( 0 )]  public float   f_float;
            [FieldOffset( 0 )]  public IntPtr  psz_string;
            [FieldOffset( 0 )]  public IntPtr  p_address;
            [FieldOffset( 0 )]  public IntPtr  p_object;
            [FieldOffset( 0 )]  public IntPtr  p_list;
            [FieldOffset( 0 )]  public Int64   i_time;

            [FieldOffset( 0 )]  public IntPtr  psz_name;
            [FieldOffset( 4 )]  public Int32   i_object_id;
        }
        #endregion
        //---------------------------------------------------------------------

        //---------------------------------------------------------------------
        // -- libvlc api
        #region libvlc api
        [DllImport("libvlc")]
        static extern int VLC_Create();
        [DllImport("libvlc")]
        static extern Error VLC_Init(int iVLC, int Argc, string[] Argv);
        [DllImport("libvlc")]
        static extern Error VLC_AddIntf(int iVLC, string Name, bool Block, bool Play);
        [DllImport("libvlc")]
        static extern Error VLC_Die(int iVLC);
        [DllImport("libvlc")]
        static extern string VLC_Error();
        [DllImport("libvlc")]
        static extern string VLC_Version();
        [DllImport("libvlc")]
        static extern Error VLC_CleanUp(int iVLC);
        [DllImport("libvlc")]
        static extern Error VLC_Destroy(int iVLC);
        [DllImport("libvlc")]
        static extern Error VLC_AddTarget(int iVLC, string Target, string[] Options, int OptionsCount, int Mode, int Pos);
        [DllImport("libvlc")]
        static extern Error VLC_Play(int iVLC);
        [DllImport("libvlc")]
        static extern Error VLC_Pause(int iVLC);
        [DllImport("libvlc")]
        static extern Error VLC_Stop(int iVLC);
        [DllImport("libvlc")]
        static extern bool VLC_IsPlaying(int iVLC);
        [DllImport("libvlc")]
        static extern float VLC_PositionGet(int iVLC);
        [DllImport("libvlc")]
        static extern float VLC_PositionSet(int iVLC, float Pos);
        [DllImport("libvlc")]
        static extern int VLC_TimeGet(int iVLC);
        [DllImport("libvlc")]
        static extern Error VLC_TimeSet(int iVLC, int Seconds, bool Relative);
        [DllImport("libvlc")]
        static extern int VLC_LengthGet(int iVLC);
        [DllImport("libvlc")]
        static extern float VLC_SpeedFaster(int iVLC);
        [DllImport("libvlc")]
        static extern float VLC_SpeedSlower(int iVLC);
        [DllImport("libvlc")]
        static extern int VLC_PlaylistIndex(int iVLC);
        [DllImport("libvlc")]
        static extern int VLC_PlaylistNumberOfItems(int iVLC);
        [DllImport("libvlc")]
        static extern Error VLC_PlaylistNext(int iVLC);
        [DllImport("libvlc")]
        static extern Error VLC_PlaylistPrev(int iVLC);
        [DllImport("libvlc")]
        static extern Error VLC_PlaylistClear(int iVLC);
        [DllImport("libvlc")]
        static extern int VLC_VolumeSet(int iVLC, int Volume);
        [DllImport("libvlc")]
        static extern int VLC_VolumeGet(int iVLC);
        [DllImport("libvlc")]
        static extern Error VLC_VolumeMute(int iVLC);
        [DllImport("libvlc")]
        static extern Error VLC_FullScreen(int iVLC);
        [DllImport("libvlc")]
        static extern Error VLC_VariableType( int iVLC, string Name, ref int iType );
        [DllImport("libvlc")]
        static extern Error VLC_VariableSet(int iVLC,string Name,vlc_value_t value );
        [DllImport("libvlc")]
        static extern Error VLC_VariableGet(int iVLC,string Name,ref vlc_value_t value );
        [DllImport("libvlc")]
        static extern string VLC_Error ( int i_err );
        #endregion
        //---------------------------------------------------------------------

        //---------------------------------------------------------------------
        // -- local members
        #region local members
        private int                                     m_iVlcHandle        = -1;
        private Control                                 m_wndOutput         = null;
        private string                                  m_strVlcInstallDir  = "";
        private string                                  m_strLastError      = "";
        #endregion
        //---------------------------------------------------------------------
        
        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   LibVlc Constructor
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public Vlc()
        {
            m_strVlcInstallDir = QueryVlcInstallPath();
        }

        /*=======================================================================*
         *=======================================================================*
         *==                IDisposable MEMBERS                            ==*
         *=======================================================================*
         *=======================================================================*/
        #region IDisposable Members

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   Dispose
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public void Dispose()
        {
            if(m_iVlcHandle != -1)
            {
                try
                {
                    VLC_CleanUp(m_iVlcHandle);
                    VLC_Destroy(m_iVlcHandle);
                    VideoOutput = null;
                }
                catch { }
            }
                m_iVlcHandle = -1;
            }
        #endregion

        /*=======================================================================*
         *=======================================================================*
         *==                PUBLIC PROPERTIES                              ==*
         *=======================================================================*
         *=======================================================================*/
        #region PUBLIC PROPERTIES

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   VlcInstallDir
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public string VlcInstallDir
        {
            get{return m_strVlcInstallDir;}
            set{m_strVlcInstallDir = value;}
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   IsInitialized
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public bool IsInitialized
        {
            get{return (m_iVlcHandle != -1);}
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   VideoOutput
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public Control VideoOutput
        {
            get{return m_wndOutput;}
            set
            {
                // clear old window
                if(m_wndOutput != null)
                {
                    m_wndOutput.Resize      -= new EventHandler( wndOutput_Resize );
                    m_wndOutput         = null;
                    if(m_iVlcHandle != -1)
                        SetVariable("drawable",0);
                }

                // set new
                m_wndOutput = value;
                if(m_wndOutput != null) 
                {
                    if(m_iVlcHandle != -1)
                        SetVariable("drawable",m_wndOutput.Handle.ToInt32());
                    m_wndOutput.Resize += new EventHandler( wndOutput_Resize );
                    wndOutput_Resize(null,null);
                }
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   LastError
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public string LastError
        {
            get{return m_strLastError;}
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   IsPlaying
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public bool IsPlaying
        {
            get 
            { 
                if(m_iVlcHandle == -1)
                {
                    m_strLastError = "LibVlc is not initialzed";
                    return false;
                }

                try
                {
                    return VLC_IsPlaying(m_iVlcHandle); 
                }
                catch(Exception ex)
                {
                    m_strLastError = ex.Message;
                    return false;
                }
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   LengthGet
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public int LengthGet
        {
            get
            {
                if(m_iVlcHandle == -1)
                {
                    m_strLastError = "LibVlc is not initialzed";
                    return -1;
                }

                try
                {
                    return VLC_LengthGet(m_iVlcHandle);
                }
                catch(Exception ex)
                {
                    m_strLastError = ex.Message;
                    return -1;
                }
            }

        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   TimeGet
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public int TimeGet
        {
            get
            {
                if(m_iVlcHandle == -1)
                {
                    m_strLastError = "LibVlc is not initialzed";
                    return -1;
                }

                try
                {
                    return VLC_TimeGet(m_iVlcHandle);
                }
                catch(Exception ex)
                {
                    m_strLastError = ex.Message;
                    return -1;
                }
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   PositionGet
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public float PositionGet
        {
            get
            {
                if(m_iVlcHandle == -1)
                {
                    m_strLastError = "LibVlc is not initialzed";
                    return -1;
                }

                try
                {
                    return VLC_PositionGet(m_iVlcHandle);
                }
                catch(Exception ex)
                {
                    m_strLastError = ex.Message;
                    return -1;
                }
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   VolumeGet
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public int VolumeGet
        {
            get
            {
                if(m_iVlcHandle == -1)
                {
                    m_strLastError = "LibVlc is not initialzed";
                    return -1;
                }

                try
                {
                    return VLC_VolumeGet(m_iVlcHandle);
                }
                catch(Exception ex)
                {
                    m_strLastError = ex.Message;
                    return -1;
                }
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   Fullscreen
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public bool Fullscreen
        {
            get
            {
                int iIsFullScreen = 0;
                if(GetVariable("fullscreen",ref iIsFullScreen) == Error.Success)
                    if(iIsFullScreen != 0)
                        return true;
                return false;
                
            }
            set
            {
                int iFullScreen = value ? 1 : 0;;
                SetVariable("fullscreen",iFullScreen);
            }
        }

        #endregion



        /*=======================================================================*
         *=======================================================================*
         *==                PUBLIC METHODS                                 ==*
         *=======================================================================*
         *=======================================================================*/
        #region PUBLIC METHODS


        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   Initialize
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public bool Initialize()
        {
            // check if already initializes
            if(m_iVlcHandle != -1)
                return true;

            // try init
            try
            {
                // create instance
                m_iVlcHandle = VLC_Create();
                if (m_iVlcHandle < 0)
                {
                    m_strLastError = "Failed to create VLC instance";
                    return false;
                }

                // make init optinons
                string[] strInitOptions = { "vlc",
                                            "--no-one-instance",
                                            "--no-loop",
                                            "--no-drop-late-frames",
                                            "--disable-screensaver"};
                if(m_strVlcInstallDir.Length > 0)
                    strInitOptions[0] = m_strVlcInstallDir + @"\vlc";

                // init libvlc
                Error errVlcLib = VLC_Init(m_iVlcHandle, strInitOptions.Length, strInitOptions);
                if (errVlcLib != Error.Success)
                {
                    VLC_Destroy(m_iVlcHandle);
                    m_strLastError = "Failed to initialise VLC";
                    m_iVlcHandle   = -1;
                    return false;
                }
                
            }
            catch
            {
                m_strLastError = "Could not find libvlc";
                return false;
            }            

            // check output window
            if(m_wndOutput != null) 
            {
                SetVariable("drawable",m_wndOutput.Handle.ToInt32());
                wndOutput_Resize(null,null);
            }

            // OK
            return true;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   AddTarget
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public Error AddTarget(string Target)
        {
            if(m_iVlcHandle == -1)
            {
                m_strLastError = "LibVlc is not initialzed";
                return Error.NoInit;
            }

            Error enmErr = Error.Success;
            try
            {
                enmErr = VLC_AddTarget(m_iVlcHandle, 
                                         Target, 
                                         null, 
                                         0,
                                        (int)Mode.Append, 
                                        (int)Pos.End);
            }
            catch(Exception ex)
            {
                m_strLastError = ex.Message;
                return Error.Execption;
            }

            if((int)enmErr < 0)
            {
                m_strLastError = VLC_Error((int)enmErr);
                return enmErr;
            }

            // OK
            return Error.Success;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   AddTarget
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public Error AddTarget(string Target, string[] Options)
        {
            if(m_iVlcHandle == -1)
            {
                m_strLastError = "LibVlc is not initialzed";
                return Error.NoInit;
            }

            // check options
            int iOptionsCount = 0;
            if(Options != null)
                iOptionsCount = Options.Length;

            // add 
            Error enmErr = Error.Success;
            try
            {
                enmErr = VLC_AddTarget(m_iVlcHandle, 
                                         Target, 
                                         Options, 
                                         iOptionsCount, 
                                         (int)Mode.Append, 
                                         (int)Pos.End);
            }
            catch(Exception ex)
            {
                m_strLastError = ex.Message;
                return Error.Execption;
            }

            if((int)enmErr < 0)
            {
                m_strLastError = VLC_Error((int)enmErr);
                return enmErr;
            }

            // OK
            return Error.Success;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   Play
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public Error Play()
        {
            if(m_iVlcHandle == -1)
            {
                m_strLastError = "LibVlc is not initialzed";
                return Error.NoInit;
            }

            Error enmErr = Error.Success;
            try
            {
                enmErr = VLC_Play(m_iVlcHandle);
            }
            catch(Exception ex)
            {
                m_strLastError = ex.Message;
                return Error.Execption;
            }

            if((int)enmErr < 0)
            {
                m_strLastError = VLC_Error((int)enmErr);
                return enmErr;
            }

            // OK
            return Error.Success;

        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   Pause
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public Error Pause()
        {
            if(m_iVlcHandle == -1)
            {
                m_strLastError = "LibVlc is not initialzed";
                return Error.NoInit;
            }

            Error enmErr = Error.Success;
            try
            {
                enmErr = VLC_Pause(m_iVlcHandle);
            }
            catch(Exception ex)
            {
                m_strLastError = ex.Message;
                return Error.Execption;
            }

            if((int)enmErr < 0)
            {
                m_strLastError = VLC_Error((int)enmErr);
                return enmErr;
            }

            // OK
            return Error.Success;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   Stop
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public Error Stop()
        {
            if(m_iVlcHandle == -1)
            {
                m_strLastError = "LibVlc is not initialzed";
                return Error.NoInit;
            }
            
            Error enmErr = Error.Success;
            try
            {
                enmErr = VLC_Stop(m_iVlcHandle);
            }
            catch(Exception ex)
            {
                m_strLastError = ex.Message;
                return Error.Execption;
            }

            if((int)enmErr < 0)
            {
                m_strLastError = VLC_Error((int)enmErr);
                return enmErr;
            }

            // OK
            return Error.Success;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   SpeedFaster
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public float SpeedFaster()
        {
            if(m_iVlcHandle == -1)
            {
                m_strLastError = "LibVlc is not initialzed";
                return -1;
            }
            
            Error enmErr = Error.Success;
            try
            {
                return VLC_SpeedFaster(m_iVlcHandle);
            }
            catch(Exception ex)
            {
                m_strLastError = ex.Message;
                return -1;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   SpeedSlower
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public float SpeedSlower()
        {
            if(m_iVlcHandle == -1)
            {
                m_strLastError = "LibVlc is not initialzed";
                return -1;
            }
            
            Error enmErr = Error.Success;
            try
            {
                return VLC_SpeedSlower(m_iVlcHandle);
            }
            catch(Exception ex)
            {
                m_strLastError = ex.Message;
                return -1;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   PlaylistNext
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public Error PlaylistNext()
        {
            if(m_iVlcHandle == -1)
            {
                m_strLastError = "LibVlc is not initialzed";
                return Error.NoInit;
            }
            Error enmErr = Error.Success;
            try
            {
                enmErr = VLC_PlaylistNext(m_iVlcHandle);
            }
            catch(Exception ex)
            {
                m_strLastError = ex.Message;
                return Error.Execption;
            }

            if((int)enmErr < 0)
            {
                m_strLastError = VLC_Error((int)enmErr);
                return enmErr;
            }

            // OK
            return Error.Success;
            

        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   PlaylistPrevious
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public Error PlaylistPrevious()
        {
            if(m_iVlcHandle == -1)
            {
                m_strLastError = "LibVlc is not initialzed";
                return Error.NoInit;
            }
            
            Error enmErr = Error.Success;
            try
            {
                enmErr = VLC_PlaylistPrev(m_iVlcHandle);
            }
            catch(Exception ex)
            {
                m_strLastError = ex.Message;
                return Error.Execption;
            }

            if((int)enmErr < 0)
            {
                m_strLastError = VLC_Error((int)enmErr);
                return enmErr;
            }

            // OK
            return Error.Success;

        }


        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   PlaylistClear
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public Error PlaylistClear()
        {
            if(m_iVlcHandle == -1)
            {
                m_strLastError = "LibVlc is not initialzed";
                return Error.NoInit;
            }

            Error enmErr = Error.Success;
            try
            {
                enmErr = VLC_PlaylistClear(m_iVlcHandle);
            }
            catch(Exception ex)
            {
                m_strLastError = ex.Message;
                return Error.Execption;
            }

            if((int)enmErr < 0)
            {
                m_strLastError = VLC_Error((int)enmErr);
                return enmErr;
            }

            // OK
            return Error.Success;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   TimeSet
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public Error TimeSet(int newPosition, bool bRelative)
        {
            if(m_iVlcHandle == -1)
            {
                m_strLastError = "LibVlc is not initialzed";
                return Error.NoInit;
            }

            Error enmErr = Error.Success;
            try
            {
                enmErr = VLC_TimeSet(m_iVlcHandle, newPosition, bRelative);
            }
            catch(Exception ex)
            {
                m_strLastError = ex.Message;
                return Error.Execption;
            }

            if((int)enmErr < 0)
            {
                m_strLastError = VLC_Error((int)enmErr);
                return enmErr;
            }

            // OK
            return Error.Success;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   PositionSet
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public float PositionSet(float newPosition)
        {
            if(m_iVlcHandle == -1)
            {
                m_strLastError = "LibVlc is not initialzed";
                return -1;
            }

            try
            {
                return VLC_PositionSet(m_iVlcHandle, newPosition);
            }
            catch(Exception ex)
            {
                m_strLastError = ex.Message;
                return -1;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   VolumeSet
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public int VolumeSet(int newVolume)
        {
            if(m_iVlcHandle == -1)
            {
                m_strLastError = "LibVlc is not initialzed";
                return -1;
            }

            Error enmErr = Error.Success;
            try
            {
                return VLC_VolumeSet(m_iVlcHandle, newVolume);
            }
            catch(Exception ex)
            {
                m_strLastError = ex.Message;
                return -1;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   VolumeMute
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public Error VolumeMute()
        {
            if(m_iVlcHandle == -1)
            {
                m_strLastError = "LibVlc is not initialzed";
                return Error.NoInit;
            }

            Error enmErr = Error.Success;
            try
            {
                enmErr = VLC_VolumeMute(m_iVlcHandle);
            }
            catch(Exception ex)
            {
                m_strLastError = ex.Message;
                return Error.Execption;
            }

            if((int)enmErr < 0)
            {
                m_strLastError = VLC_Error((int)enmErr);
                return enmErr;
            }

            // OK
            return Error.Success;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   SetVariable
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public Error SetVariable(string strName, Int32 Value)
        {
            if(m_iVlcHandle == -1)
            {
                m_strLastError = "LibVlc is not initialzed";
                return Error.NoInit;
            }

            Error enmErr = Error.Success;
            try
            {
                // create vlc value
                vlc_value_t val = new vlc_value_t();
                val.i_int       = Value;

                // set variable
                enmErr = VLC_VariableSet(m_iVlcHandle,strName,val);
            }
            catch(Exception ex)
            {
                m_strLastError = ex.Message;
                return Error.Execption;
            }

            if((int)enmErr < 0)
            {
                m_strLastError = VLC_Error((int)enmErr);
                return enmErr;
            }

            // OK
            return Error.Success;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   SetVariable
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public Error GetVariable(string strName, ref int Value)
        {
            if(m_iVlcHandle == -1)
            {
                m_strLastError = "LibVlc is not initialzed";
                return Error.NoInit;
            }



            Error enmErr = Error.Success;
            try
            {
                // create vlc value
                vlc_value_t val = new vlc_value_t();

                // set variable
                enmErr = VLC_VariableGet(m_iVlcHandle,strName,ref val);
                Value = val.i_int;
            }
            catch(Exception ex)
            {
                m_strLastError = ex.Message;
                return Error.Execption;
            }

            if((int)enmErr < 0)
            {
                m_strLastError = VLC_Error((int)enmErr);
                return enmErr;
            }

            // OK
            return Error.Success;
        }


        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   ToggleFullscreen
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public Error ToggleFullscreen()
        {
            if(m_iVlcHandle == -1)
            {
                m_strLastError = "LibVlc is not initialzed";
                return Error.NoInit;
            }

            Error enmErr = Error.Success;
            try
            {
                enmErr = VLC_FullScreen(m_iVlcHandle);
            }
            catch(Exception ex)
            {
                m_strLastError = ex.Message;
                return Error.Execption;
            }

            if((int)enmErr < 0)
            {
                m_strLastError = VLC_Error((int)enmErr);
                return enmErr;
            }

            // OK
            return Error.Success;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   ToggleFullscreen
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        public Error PressKey(string strKey)
        {
            if(m_iVlcHandle == -1)
            {
                m_strLastError = "LibVlc is not initialzed";
                return Error.NoInit;
            }

            Error enmErr = Error.Success;
            try
            {
                // create vlc value
                vlc_value_t valKey = new vlc_value_t();

                // get variable
                enmErr = VLC_VariableGet(m_iVlcHandle,strKey,ref valKey);
                if(enmErr == Error.Success)
                {// set pressed
                    enmErr = VLC_VariableSet(m_iVlcHandle,"key-pressed",valKey);
                }
            }
            catch(Exception ex)
            {
                m_strLastError = ex.Message;
                return Error.Execption;
            }

            if((int)enmErr < 0)
            {
                m_strLastError = VLC_Error((int)enmErr);
                return enmErr;
            }

            // OK
            return Error.Success;
        }

        #endregion



        /*=======================================================================*
         *=======================================================================*
         *==                PRIVATE METHODS                                ==*
         *=======================================================================*
         *=======================================================================*/
        #region PRIVATE METHODS


        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   QueryVlcInstallPath
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        private string QueryVlcInstallPath()
        {
            // open registry
            RegistryKey regkeyVlcInstallPathKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\VideoLAN\VLC");
            if(regkeyVlcInstallPathKey == null)
                return "";
            return (string)regkeyVlcInstallPathKey.GetValue("InstallDir","");
        }

        #endregion

        /*=======================================================================*
         *=======================================================================*
         *==                EVENT METHODS                                  ==*
         *=======================================================================*
         *=======================================================================*/
        #region EVENT METHODS


        /// -------------------------------------------------------------------
        /// <summary>
        /// Method name      :   wndOutput_Resize
        /// Author         :   Odysee
        ///   Date         :   10.11.2006
        /// </summary>
        /// -------------------------------------------------------------------
        void wndOutput_Resize( object sender, EventArgs e )
        {
            if(m_iVlcHandle != -1)
            {
                SetVariable("conf::width", m_wndOutput.ClientRectangle.Width);
                SetVariable("conf::height",m_wndOutput.ClientRectangle.Height);
            }

        }

        
        #endregion
    }
}

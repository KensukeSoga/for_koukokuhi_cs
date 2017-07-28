using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Lion.Schema;
using System.Collections;

using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHView.Detail;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Lion.ProcessController.MastGet;
using Isid.KKH.Lion.Utility;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using System.Runtime.InteropServices;

namespace Isid.KKH.Lion.Utility
{
    /// <summary>
    /// マスタタイムスタンプ取得処理 
    /// </summary>
    /// <remarks>
    ///   修正管理 
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2012/2/6</description>
    ///       <description>Fourm K.T</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class KKHLionTimeStamp
    {
        //ファイル接続の為の構造体 
        //接続切断するWin32 API を宣言    
        [DllImport("mpr.dll", EntryPoint = "WNetCancelConnection2", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]    
        private static extern int WNetCancelConnection2(string lpName, Int32 dwFlags, bool fForce);

        //認証情報を使って接続するWin32 API宣言
        [DllImport("mpr.dll", EntryPoint = "WNetAddConnection2", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        private static extern int WNetAddConnection2(ref NETRESOURCE lpNetResource, string lpPassword, string lpUsername, Int32 dwFlags);

        //構造体 
        [StructLayout(LayoutKind.Sequential)]    
        internal struct NETRESOURCE    
        {
            public int dwScope;　　　　 // Added 
            public int dwType;
            public int dwDisplayType;　 // Added 
            public int dwUsage;　　　　 // Added 
            public string lpLocalName;
            public string lpRemoteName;
            public string lpComment;　　// Added 
            public string lpProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Address"></param>
        /// <param name="Pass"></param>
        /// <param name="TempAddress"></param>
        /// <param name="filenm"></param>
        /// <param name="sybt"></param>
        /// <param name="_naviParameter"></param>
        /// <returns></returns>
        public Boolean findMastGet(string Address, 
            string Pass, 
            string TempAddress, 
            string filenm, 
            string sybt,
            KKHNaviParameter _naviParameter)
        {

            //サーバ、DBの更新日付用変数
            DateTime dtFilesv = new DateTime();
            DateTime dtFilelcl = new DateTime();

            //更新フラグ設定（初期化） 
            Boolean newflag = false;

            try
            {
                //タイムスタンプ取得（マスタから）.
                CommonProcessController commonProcessController = CommonProcessController.GetInstance();
                FindCommonByCondServiceResult comResult = commonProcessController.FindCommonByCond(
                                                                                                _naviParameter.strEsqId,
                                                                                                _naviParameter.strEgcd,
                                                                                                _naviParameter.strTksKgyCd,
                                                                                                _naviParameter.strTksBmnSeqNo,
                                                                                                _naviParameter.strTksTntSeqNo,
                                                                                                KKHLionConst.C_WRKT_SYBT,
                                                                                                KKHLionConst.C_WRKTT_FLD1);
                if (comResult.CommonDataSet.SystemCommon.Count != 0)
                {
                    //種別により取得するフィールド変更
                    //番組マスタ
                    if (sybt.Equals(KKHLionConst.C_WRFL_TVBMST))
                    {
                        //日付がなかったら強制INS
                        if (comResult.CommonDataSet.SystemCommon[0].field2 == "")
                        {
                            newflag = true;
                        }
                        else
                        {
                            dtFilelcl = DateTime.Parse(comResult.CommonDataSet.SystemCommon[0].field2.ToString());
                        }
                    }
                    //ラジオ番組マスタ 
                    else if (sybt.Equals(KKHLionConst.C_WRFL_RDBMST))
                    {
                        //日付がなかったら強制INS
                        if (comResult.CommonDataSet.SystemCommon[0].field3 == "")
                        {
                            newflag = true;
                        }
                        else
                        {
                            dtFilelcl = DateTime.Parse(comResult.CommonDataSet.SystemCommon[0].field3.ToString());
                        }

                    }
                    //テレビ局スタ 
                    else if (sybt.Equals(KKHLionConst.C_WRFL_TVKMST))
                    {
                        //日付がなかったら強制INS
                        if (comResult.CommonDataSet.SystemCommon[0].field4 == "")
                        {
                            newflag = true;
                        }
                        else
                        {
                            dtFilelcl = DateTime.Parse(comResult.CommonDataSet.SystemCommon[0].field4.ToString());
                        }

                    }
                    //ラジオ局マスタ 
                    else if (sybt.Equals(KKHLionConst.C_WRFL_RDKMST))
                    {
                        //日付がなかったら強制INS
                        if (comResult.CommonDataSet.SystemCommon[0].field5 == "")
                        {
                            newflag = true;
                        }
                        else
                        {
                            dtFilelcl = DateTime.Parse(comResult.CommonDataSet.SystemCommon[0].field5.ToString());
                        }

                    }
                    //テレビ料金マスタ 
                    else if (sybt.Equals(KKHLionConst.C_WRFL_TVRMST))
                    {
                        //日付がなかったら強制INS
                        if (comResult.CommonDataSet.SystemCommon[0].field6 == "")
                        {
                            newflag = true;
                        }
                        else
                        {
                            dtFilelcl = DateTime.Parse(comResult.CommonDataSet.SystemCommon[0].field6.ToString());
                        }

                    }
                    //ラジオ料金マスタ 
                    else if (sybt.Equals(KKHLionConst.C_WRFL_RDRMST))
                    {
                        //日付がなかったら強制INS
                        if (comResult.CommonDataSet.SystemCommon[0].field7 == "")
                        {
                            newflag = true;
                        }
                        else
                        {
                            dtFilelcl = DateTime.Parse(comResult.CommonDataSet.SystemCommon[0].field7.ToString());
                        }

                    }
                    //テレビCM秒数マスタ 
                    else if (sybt.Equals(KKHLionConst.C_WRFL_TVCMST))
                    {
                        ////日付がなかったら強制INS
                        //if (comResult.CommonDataSet.SystemCommon[0].field8 == "")
                        //{
                        //    newflag = true;
                        //}
                        //else
                        //{
                        //    dtFilelcl = DateTime.Parse(comResult.CommonDataSet.SystemCommon[0].field8.ToString());
                        //}

                        // CM秒数データはタイムスタンプを見ないように対応
                        newflag = true;
                    }
                    //ラジオCM秒数マスタ 
                    else if (sybt.Equals(KKHLionConst.C_WRFL_RDCMST))
                    {
                        ////日付がなかったら強制INS
                        //if (comResult.CommonDataSet.SystemCommon[0].field9 == "")
                        //{
                        //    newflag = true;
                        //}
                        //else
                        //{
                        //    dtFilelcl = DateTime.Parse(comResult.CommonDataSet.SystemCommon[0].field9.ToString());
                        //}

                        // CM秒数データはタイムスタンプを見ないように対応 
                        newflag = true;
                    }

                }
                else
                {
                    //処理無し 
                    return false;
                }



                ////ファイル共有サーバ接続認証          
                //string shareName = Address;
                //// 共有パス　                       
                //NETRESOURCE netResource = new NETRESOURCE();
                //netResource.dwScope = 0;
                //netResource.dwType = 1;
                //netResource.dwDisplayType = 0;
                //netResource.dwUsage = 0;
                //netResource.lpLocalName = ""; // ネットワークドライブにする場合は"z:"などドライブレター設定              
                //netResource.lpRemoteName = shareName;
                //netResource.lpProvider = "";
                //string password = Pass;
                //string userId = @"ESC-NET\" + _naviParameter.strEsqId;
                //int ret = 0;
                //try
                //{
                //    //既に接続してる場合があるので一旦切断する                
                //    ret = WNetCancelConnection2(shareName, 0, true);
                //    //共有フォルダに認証情報を使って接続                
                //    ret = WNetAddConnection2(ref netResource, password, userId, 0);
                //}
                //catch (Exception)
                //{
                //    //エラー処理            
                //    return false;
                //}    


                //サーバのタイムスタンプ取得 
                dtFilesv = System.IO.File.GetLastWriteTime(Address + filenm);

                //ローカル、サーバを比較し一致しなかったら 
                //ファイルコピーを行う 
                //if (dtFilesv.ToString("yyyy/MM/dd HH:mm:ss") < dtFilelcl.ToString("yyyy/MM/dd HH:mm:ss") || newflag == true)
                if (dtFilesv > dtFilelcl || newflag == true)
                {
                    //タイムスタンプアップデート実行 
                    //パラメータセット 
                    ArrayList param = new ArrayList();
                    param.Add(KKHLionConst.C_WRKT_SYBT);
                    param.Add(KKHLionConst.C_WRKTT_FLD1);
                    param.Add(sybt);
                    param.Add(dtFilesv.ToString("yyyy/MM/dd HH:mm:ss"));
                    //実行 
                    Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController processcontroller = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
                    processcontroller.UpdateTimeStampData(param, _naviParameter);
                    //処理を行う
                    return true;
                }
                else
                {
                    //処理無し 
                    return false;
                }
            }
            catch
            {
                //処理無し 
                return false;
            }

            //処理を行う
            //return true;
        }

        /// <summary>
        /// マスタファイルゲット 
        /// </summary>
        /// <param name="Address"></param>
        /// <param name="Pass"></param>
        /// <param name="TempAddress"></param>
        /// <param name="filenm"></param>
        /// <returns></returns>
        private Boolean MastCopy(string Address, string Pass, string TempAddress, string filenm)
        {
            try
            {
                //ファイルを強制コピー（上書き）する。.
                System.IO.File.Copy(Address + filenm, TempAddress + filenm,true);
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}

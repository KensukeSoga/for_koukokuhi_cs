using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Isid.KKH.Acom.Utility
{
    class KkhConstAcom
    {
        #region 定数

        /// <summary>
        /// 数値変換用エラー数値(-9.9m)
        /// </summary>
        public const Decimal DECIMAL_PARSE_CHECK_ERR_NUM = -9.9m;

        /// <summary>
        /// フィルタ(IrYyMm)
        /// </summary>
        public const string FILTER_IRYYMM = "IrYyMm = ";

        /// <summary>
        /// フィルタ(Flg)
        /// </summary>
        public const string FILTER_SAISINFLG1 = "SaisinFlg = '1'";

        /// <summary>
        /// フィルタ(並び順)
        /// </summary>
        public const string FILTER_ORDER_RIREKI = "IRBAN, IRROWBAN, RIRENO DESC";

        ///// <summary>
        ///// ログフォルダ名(C:\TMP)
        ///// </summary>
        //public const string LOG_DIR_NAME_TMP = @"C:\TMP";

        ///// <summary>
        ///// ログフォルダ名(C:\WORK)
        ///// </summary>
        //public const string LOG_DIR_NAME_WORK = @"C:\WORK";

        ///// <summary>
        ///// ログファイル名(RGerror.log)
        ///// </summary>
        //public const string LOGFILENAME = @"\error.log";


        /// <summary>
        /// レコード種別(H)
        /// </summary>
        public const string REC_CD = "H";


        #endregion 定数

        #region 構造体

        /// <summary>
        /// 媒体ごとのファイル長
        /// </summary>
        public struct MediaByFileSize
        {
            /// <summary>
            /// 雑誌ファイル長(558)
            /// </summary>
            public const int FILEIMP_ZASI_LENGTH = 558;

            /// <summary>
            /// 電波ファイル長(506)
            /// </summary>
            public const int FILEIMP_DENP_LENGTH = 506;

            /// <summary>
            /// 交通ファイル長(545)
            /// </summary>
            public const int FILEIMP_KOTU_LENGTH = 545;

            /// <summary>
            /// 新聞ファイル長(526)
            /// </summary>
            public const int FILEIMP_SNBN_LENGTH = 526;
        }

        /// <summary>
        /// コード名(マスタ存在チェックコード)
        /// </summary>
        public struct MasterCodeName
        {
            /// <summary>
            /// メディアコード(メディアコード)
            /// </summary>
            public const string MEDIA_CODE_NAME = "メディアコード";

            /// <summary>
            /// 色刷コード(色刷コード)
            /// </summary>
            public const string COLOR_CODE_NAME = "色刷コード";

            /// <summary>
            /// サイズコード(サイズコード)
            /// </summary>
            public const string SIZE_CODE_NAME = "サイズコード";

            /// <summary>
            /// 掲載場所コード(掲載場所コード)
            /// </summary>
            public const string KEISAI_CODE_NAME = "掲載場所コード";

            /// <summary>
            /// 記雑コード(記雑コード)
            /// </summary>
            public const string KIZATSU_CODE_NAME = "記雑コード";

            /// <summary>
            /// 朝夕コード(朝夕コード)
            /// </summary>
            public const string ASAYUU_CODE_NAME = "朝夕コード";
        }

        /// <summary>
        /// 媒体種別コード 
        /// </summary>
        public struct MediaKindCode
        {
            /// <summary>
            /// 雑誌(22)
            /// </summary>
            public const string SYBT_ZASI = "22";

            /// <summary>
            /// 電波(11)
            /// </summary>
            public const string SYBT_DENP = "11";

            /// <summary>
            /// 交通(31)
            /// </summary>
            public const string SYBT_KOTU = "31";

            /// <summary>
            /// 新聞(21)
            /// </summary>
            public const string SYBT_SNBN = "21";
        }

        /// <summary>
        /// 媒体種別名 
        /// </summary>
        public struct MediaKindName
        {
            /// <summary>
            /// 新聞  
            /// </summary>
            public const string SYBT_SNBN_NAME = "新聞";

            /// <summary>
            /// 雑誌 
            /// </summary>
            public const string SYBT_ZASI_NAME = "雑誌";

            /// <summary>
            /// 電波
            /// </summary>
            public const string SYBT_DENP_NAME = "電波";

            /// <summary>
            /// 交通 
            /// </summary>
            public const string SYBT_KOTU_NAME = "交通";
        }

        /// <summary>
        /// 媒体種別マスターキー 
        /// </summary>
        public struct MediaKindMasterKey
        {
            /// <summary>
            /// 媒体種別マスタキー 
            /// </summary>
            public const string MEDIA_KIND_MASTERKEY = "0001";

            /// <summary>
            /// 掲載場所変換マスタキー 
            /// </summary>
            public const string KEISAI_MASTERKEY = "0002";

            /// <summary>
            /// サイズコード変換マスタキー 
            /// </summary>
            public const string SIZE_MASTERKEY = "0003";

            /// <summary>
            /// 記雑コード変換マスタキー 
            /// </summary>
            public const string KIZATSU_MASTERKEY = "0004";

            /// <summary>
            /// 朝夕コード変換マスタキー 
            /// </summary>
            public const string ASAYUU_MASTERKEY = "0005";

            /// <summary>
            /// メディアコード変換マスタキー 
            /// </summary>
            public const string MEDIA_MASTERKEY = "0006";

            /// <summary>
            /// 色刷変換マスタキー 
            /// </summary>
            public const string COLOR_MASTERKEY = "0007";
        }

        /// <summary>
        /// 属性チェックタイプ 
        /// </summary>
        public struct AttributeCheckType
        {
            /// <summary>
            /// チェック種類：半角(1)
            /// </summary>
            public const int CHECKTYPE_HNKK = 1;
            /// <summary>
            /// チェック種類：全角(2)
            /// </summary>
            public const int CHECKTYPE_ZNKK = 2;
            /// <summary>
            /// チェック種類：数値(3)
            /// </summary>
            public const int CHECKTYPE_SU = 3;
            /// <summary>
            /// チェック種類：数値(4)
            /// </summary>
            public const int CHECKTYPE_NONE = 4;
        }

        /// <summary>
        /// スプレッドカラム番号 
        /// </summary>
        public struct SpreadColumunsNo
        {
            #region SPREADカラム番号
            /// <summary>
            /// SPREADカラム番号[履歴管理番号](1)
            /// </summary>
            public const int SPD_COLUMUNS_RIRENO = 1;

            /// <summary>
            /// SPREADカラム番号[発注番号](3)
            /// </summary>
            public const int SPD_COLUMUNS_IRBAN = 3;

            /// <summary>
            /// SPREADカラム番号[発注行番号](4)
            /// </summary>
            public const int SPD_COLUMUNS_IRROWBAN = 4;

            /// <summary>
            /// SPREADカラム番号[サイズコード](7)
            /// </summary>
            public const int SPD_COLUMUNS_SIZECD = 7;

            /// <summary>
            /// SPREADカラム番号[サイズ名](8)
            /// </summary>
            public const int SPD_COLUMUNS_SIZENAME = 8;

            /// <summary>
            /// SPREADカラム番号[掲載日1](9)
            /// </summary>
            public const int SPD_COLUMUNS_KEISAI1 = 9;

            /// <summary>
            /// SPREADカラム番号[掲載日2](10)
            /// </summary>
            public const int SPD_COLUMUNS_KEISAI2 = 10;

            /// <summary>
            /// SPREADカラム番号[掲載日3](11)
            /// </summary>
            public const int SPD_COLUMUNS_KEISAI3 = 11;

            /// <summary>
            /// SPREADカラム番号[掲載日4](12)
            /// </summary>
            public const int SPD_COLUMUNS_KEISAI4 = 12;

            /// <summary>
            /// SPREADカラム番号[掲載日5](13)
            /// </summary>
            public const int SPD_COLUMUNS_KEISAI5 = 13;

            /// <summary>
            /// SPREADカラム番号[形態区分コード](14)
            /// </summary>
            public const int SPD_COLUMUNS_KEITAICD = 14;

            /// <summary>
            /// SPREADカラム番号[形態区分名](15)
            /// </summary>
            public const int SPD_COLUMUNS_KEITAINAME = 15;

            /// <summary>
            /// SPREADカラム番号[依頼月1](16)
            /// </summary>
            public const int SPD_COLUMUNS_IRMONTH1 = 16;

            /// <summary>
            /// SPREADカラム番号[放送料1](17)
            /// </summary>
            public const int SPD_COLUMUNS_HOSORYO1 = 17;

            /// <summary>
            /// SPREADカラム番号[依頼月2](18)
            /// </summary>
            public const int SPD_COLUMUNS_IRMONTH2 = 18;

            /// <summary>
            /// SPREADカラム番号[放送料2](19)
            /// </summary>
            public const int SPD_COLUMUNS_HOSORYO2 = 19;

            /// <summary>
            /// SPREADカラム番号[依頼月3](20)
            /// </summary>
            public const int SPD_COLUMUNS_IRMONTH3 = 20;

            /// <summary>
            /// SPREADカラム番号[放送料3](21)
            /// </summary>
            public const int SPD_COLUMUNS_HOSORYO3 = 21;

            /// <summary>
            /// SPREADカラム番号[依頼月4](22)
            /// </summary>
            public const int SPD_COLUMUNS_IRMONTH4 = 22;

            /// <summary>
            /// SPREADカラム番号[放送料4](23)
            /// </summary>
            public const int SPD_COLUMUNS_HOSORYO4 = 23;

            /// <summary>
            /// SPREADカラム番号[依頼月5](24)
            /// </summary>
            public const int SPD_COLUMUNS_IRMONTH5 = 24;

            /// <summary>
            /// SPREADカラム番号[放送料5](25)
            /// </summary>
            public const int SPD_COLUMUNS_HOSORYO5 = 25;

            /// <summary>
            /// SPREADカラム番号[依頼月6](26)
            /// </summary>
            public const int SPD_COLUMUNS_IRMONTH6 = 26;

            /// <summary>
            /// SPREADカラム番号[放送料6](27)
            /// </summary>
            public const int SPD_COLUMUNS_HOSORYO6 = 27;

            /// <summary>
            /// SPREADカラム番号[交通掲載コード](28)
            /// </summary>
            public const int SPD_COLUMUNS_KOUTUKEICD = 28;

            /// <summary>
            /// SPREADカラム番号[交通掲載名](29)
            /// </summary>
            public const int SPD_COLUMUNS_KOUTUKEINAME = 29;

            /// <summary>
            /// SPREADカラム番号[掲載日](30)
            /// </summary>
            public const int SPD_COLUMUNS_KEISAI = 30;

            /// <summary>
            /// SPREADカラム番号[掲載料](31)
            /// </summary>
            public const int SPD_COLUMUNS_KEISAIRYO = 31;

            /// <summary>
            /// SPREADカラム番号[掲載単価](32)
            /// </summary>
            public const int SPD_COLUMUNS_KEISAITANKA = 32;

            /// <summary>
            /// SPREADカラム番号[掲載回数](33)
            /// </summary>
            public const int SPD_COLUMUNS_KEISAICNT = 33;

            /// <summary>
            /// SPREADカラム番号[色刷コード](43)
            /// </summary>
            public const int SPD_COLUMUNS_COLORCD = 43;

            /// <summary>
            /// SPREADカラム番号[デザイン変更回数](44)
            /// </summary>
            public const int SPD_COLUMUNS_DESIGNCNT = 44;

            /// <summary>
            /// SPREADカラム番号[印刷代](45)
            /// </summary>
            public const int SPD_COLUMUNS_PRINT = 45;

            /// <summary>
            /// SPREADカラム番号[差替作業料](46)
            /// </summary>
            public const int SPD_COLUMUNS_SASHIKAE = 46;

            /// <summary>
            /// SPREADカラム番号[デザイン料](47)
            /// </summary>
            public const int SPD_COLUMUNS_DESIGNRYO = 47;

            /// <summary>
            /// SPREADカラム番号[版下代](48)
            /// </summary>
            public const int SPD_COLUMUNS_HANSHITA = 48;

            /// <summary>
            /// SPREADカラム番号[製版代](49)
            /// </summary>
            public const int SPD_COLUMUNS_SEIHAN = 49;

            /// <summary>
            /// SPREADカラム番号[最新フラグ](53)
            /// </summary>
            public const int SPD_COLUMUNS_SAISINFLG = 53;

            /// <summary>
            /// SPREADカラム番号[更新区分コード](54)
            /// </summary>
            public const int SPD_COLUMUNS_KOUKBNCODE = 54;
            #endregion

            #region SPREADカラム番号(新聞)
            /// <summary>
            /// SPREADカラム番号(新聞)[発注番号](2)
            /// </summary>
            public const int SPD_COLUMUNS_SNBN_IRBAN = 2;
            /// <summary>
            /// SPREADカラム番号(新聞)[発注行番号](3)
            /// </summary>
            public const int SPD_COLUMUNS_SNBN_IRROWBAN = 3;
            /// <summary>
            /// SPREADカラム番号(新聞)[最新フラグ](34)
            /// </summary>
            public const int SPD_COLUMUNS_SNBN_SAISINFLG = 34;

            /// <summary>
            /// SPREADカラム番号(新聞)[更新区分コード](35)
            /// </summary>
            public const int SPD_COLUMUNS_SNBN_KOUKBNCODE = 35;
            #endregion
        }


        /// <summary>
        /// マスタ変換キー 
        /// </summary>
        public struct MasterConvertKey
        {
            /// <summary>
            /// 媒体種別SYBTキー 
            /// </summary>
            public const string MEDIA_KIND_SYBTKEY = "101";

            /// <summary>
            /// 掲載場所変換SYBTキー 
            /// </summary>
            public const string KEISAI_SYBTKEY = "906";

            /// <summary>
            /// サイズコード変換SYBTキー 
            /// </summary>
            public const string SIZE_SYBTKEY = "907";

            /// <summary>
            /// 記雑コード変換SYBTキー 
            /// </summary>
            public const string KIZATSU_SYBTKEY = "908";

            /// <summary>
            /// 朝夕コード変換SYBTキー 
            /// </summary>
            public const string ASAYUU_SYBTKEY = "909";

            /// <summary>
            /// メディアコード変換SYBTキー 
            /// </summary>
            public const string MEDIA_SYBTKEY = "910";

            /// <summary>
            /// 色刷変換SYBTキー 
            /// </summary>
            public const string COLOR_SYBTKEY = "911";
        }

        /// <summary>
        /// 発注取込ファイル名チェック 
        /// </summary>
        public struct InputFileNameCheckType
        {
            /// <summary>
            /// 雑誌ファイル名(Dtsmzasi*.txt)
            /// </summary>
            public const string FILENAME_ZASI = "Text Files|Dtsmzasi*.txt";

            /// <summary>
            /// 電波ファイル名(Dtsmdenp*.txt)
            /// </summary>
            public const string FILENAME_DENP = "Text Files|Dtsmdenp*.txt";

            /// <summary>
            /// 交通ファイル名(Dtsmkotu*.txt)
            /// </summary>
            public const string FILENAME_KOTU = "Text Files|Dtsmkotu*.txt";

            /// <summary>
            /// 新聞ファイル名(Dtsmsnbn*.txt)
            /// </summary>
            public const string FILENAME_SNBN = "Text Files|Dtsmsnbn*.txt";

            ///// <summary>
            ///// テキストファイル全般(*.txt)
            ///// </summary>
            //public const string FILENAME_ALL = "Text Files|*.txt";
        }

        /// <summary>
        /// メッセージ 
        /// </summary>
        public struct MessageList
        {
            /// <summary>
            /// ファイル取込(タイトル)
            /// </summary>
            public const string FILE_INPUT_TITLE = "ファイル取込";

            /// <summary>
            /// ファイル取込正常終了(登録件数1件以上)
            /// </summary>
            public const string FILE_INPUT_OK = "ファイルの取り込みが終了しました。";

            /// <summary>
            /// ファイル取込正常終了(登録件数0件)
            /// </summary>
            public const string FILE_INPUT_OK_ZERO = "取り込むデータはありませんでした。";
        }

        ///// <summary>
        ///// ログ表示非表示設定 
        ///// </summary>
        //public struct LogShowList
        //{
        //    /// <summary>
        //    /// LOG表示(002)
        //    /// </summary>
        //    public const string LOG_SHOW = "002";
        //
        //    /// <summary>
        //    ///  LOG非表示(003)
        //    /// </summary>
        //    public const string LOG_NOT_SHOW = "003";
        //
        //}

        /// <summary>
        /// 属性チェック対象カラム
        /// </summary>
        public struct AttributeCheckList
        {
            //共通  
            /// <summary>
            /// 発注番号(0)
            /// </summary>
            public const int IrBan     =0; //発注番号 

            /// <summary>
            /// 依頼区分(1)
            /// </summary>
            public const int IrKbn     =1; //依頼区分 

            /// <summary>
            /// 依頼月(2)
            /// </summary>
            public const int IrYyMm    =2; //依頼月 

            /// <summary>
            /// 売上予定年月(3)
            /// </summary>
            public const int UriYyMm   =3; //売上予定年月 

            /// <summary>
            /// 得意先コード(4)
            /// </summary>
            public const int TokuiCd   =4; //得意先コード 

            /// <summary>
            /// 営業部コード(5)
            /// </summary>
            public const int EiCode    =5; //営業部コード 

            /// <summary>
            /// 営業部名(6)
            /// </summary>
            public const int EiName    =6; //営業部名 

            /// <summary>
            /// 店番(7)
            /// </summary>
            public const int TenCd     =7; //店番 

            /// <summary>
            /// 店名(8)
            /// </summary>
            public const int TenName   =8; //店名 

            /// <summary>
            /// 商品区分(9)
            /// </summary>
            public const int SyohiKbn  =9; //商品区分 

            /// <summary>
            /// 細目区分(10)
            /// </summary>
            public const int SaiKbn    =10;//細目区分  

            /// <summary>
            /// 摘要コード(11)
            /// </summary>
            public const int TekiCd    =11;//摘要コード 

            /// <summary>
            /// 媒体コード(12)
            /// </summary>
            public const int Sybt      =12;//媒体コード 

            /// <summary>
            /// メディアコード(13)
            /// </summary>
            public const int MediaCd   =13;//メディアコード 

            /// <summary>
            /// メディア名(14)
            /// </summary>
            public const int MediaName =14;//メディア名 

            /// <summary>
            /// 依頼内容(15)
            /// </summary>
            public const int IrNai     =15;//依頼内容 

            /// <summary>
            /// 行番号(16)
            /// </summary>
            public const int IrRowBan  =16;//行番号 

            /// <summary>
            /// 担当者名(17)
            /// </summary>
            public const int TanName   =17;//担当者名 

            /// <summary>
            /// 担当者勤務部署名(18)
            /// </summary>
            public const int TanKinName=18;//担当者勤務部署名 

            /// <summary>
            /// 予算区分(19)
            /// </summary>
            public const int YosaKbn   =19;//予算区分 

            /// <summary>
            /// 按分種別(20)
            /// </summary>
            public const int AnSyube   =20;//按分種別 

            /// <summary>
            /// 備考1(21)
            /// </summary>
            public const int Bikou1    =21;//備考1 

            /// <summary>
            /// 備考2(22)
            /// </summary>
            public const int Bikou2    =22;//備考2

            //雑誌 
            /// <summary>
            /// 色印コード(23)
            /// </summary>
            public const int ColorCd    =23;//色印コード 

            /// <summary>
            /// サイズコード(24)
            /// </summary>
            public const int SizeCd     =24;//サイズコード 

            /// <summary>
            /// サイズ名(25)
            /// </summary>
            public const int SizeName   =25;//サイズ名 

            /// <summary>
            /// 発売日1(26)
            /// </summary>
            public const int Keisai1    =26;//発売日1 

            /// <summary>
            /// 発売日2(27)
            /// </summary>
            public const int Keisai2    =27;//発売日2

            /// <summary>
            /// /発売日3(28)
            /// </summary>
            public const int Keisai3    =28;//発売日3

            /// <summary>
            /// 発売日4(29)
            /// </summary>
            public const int Keisai4    =29;//発売日4

            /// <summary>
            /// 発売日5(30)
            /// </summary>
            public const int Keisai5    =30;//発売日5

            /// <summary>
            /// 掲載回数(31)
            /// </summary>
            public const int KeisaiCnt  =31;//掲載回数 

            /// <summary>
            /// 掲載単価(32)
            /// </summary>
            public const int KeisaiTanka=32;//掲載単価 

            /// <summary>
            /// 掲載料(33)
            /// </summary>
            public const int KeisaiRyo  =33;//掲載料 

            /// <summary>
            /// デザイン変更回数(34)
            /// </summary>
            public const int DesignCnt  =34;//デザイン変更回数 

            /// <summary>
            /// デザイン料(35)
            /// </summary>
            public const int DesignRyo  =35;//デザイン料 

            /// <summary>
            /// 版下代(36)
            /// </summary>
            public const int HanShitaRyo=36;//版下代 

            /// <summary>
            /// 製版代(37)
            /// </summary>
            public const int SeiHanRyo  =37;//製版代 

            /// <summary>
            /// 登録年月日(38)
            /// </summary>
            public const int TouDate    =38;//登録年月日 

            /// <summary>
            /// 変更年月日(39)
            /// </summary>
            public const int HenDate    =39;//変更年月日 

            /// <summary>
            /// 取消年月日(40)
            /// </summary>
            public const int TorDate    =40;//取消年月日 

            //電波 
            /// <summary>
            /// 形態区分  (41)
            /// </summary>
            public const int KeitaiCd    =41;//形態区分    
             
            /// <summary>
            /// 形態区分名(42)
            /// </summary>
            public const int KeitaiName  =42;//形態区分名   

            /// <summary>
            /// 依頼月1(43)
            /// </summary>
            public const int IrMonth1    =43;//依頼月1     

            /// <summary>
            /// 放送料1(44)
            /// </summary>
            public const int HosoRyo1    =44;//放送料1        

            /// <summary>
            /// 依頼月2 (45)
            /// </summary>
            public const int IrMonth2    =45;//依頼月2   

            /// <summary>
            /// 放送料2 (46)
            /// </summary>
            public const int HosoRyo2    =46;//放送料2    

            /// <summary>
            /// 依頼月3(47)
            /// </summary>
            public const int IrMonth3    =47;//依頼月3  

            /// <summary>
            /// 放送料3(48)
            /// </summary>
            public const int HosoRyo3    =48;//放送料3  

            /// <summary>
            /// 依頼月4(49)
            /// </summary>
            public const int IrMonth4    =49;//依頼月4    

            /// <summary>
            /// 放送料4(50)
            /// </summary>
            public const int HosoRyo4    =50;//放送料4 

            /// <summary>
            /// 依頼月5(51)
            /// </summary>
            public const int IrMonth5    =51;//依頼月5 

            /// <summary>
            /// 放送料5(52)
            /// </summary>
            public const int HosoRyo5    =52;//放送料5 

            /// <summary>
            /// 依頼月6(53)
            /// </summary>
            public const int IrMonth6    =53;//依頼月6 

            /// <summary>
            /// 放送料6(54)
            /// </summary>
            public const int HosoRyo6    =54;//放送料6 

            //交通                              
            /// <summary>
            /// 種類コード(55)
            /// </summary>
            public const int KotuKeiCd   = 55; //種類コード 

            /// <summary>
            /// サイズ名(56)
            /// </summary>
            public const int KotuKeiName = 56; //サイズ名 

            /// <summary>
            /// 掲載日(57)
            /// </summary>
            public const int Keisai      = 57; //掲載日 

            /// <summary>
            /// 印刷代(58)
            /// </summary>
            public const int PrintRyo    = 58; //印刷代 

            /// <summary>
            /// 差替作業料(59)
            /// </summary>
            public const int SashikaeRyo = 59; //差替作業料 


            //新聞 
            /// <summary>
            /// 種類コード(60)
            /// </summary>
            public const int PlaceCd    = 60; //種類コード   

            /// <summary>
            /// サイズ名(61)
            /// </summary>
            public const int Sybt1Cd    = 61; //サイズ名    

            /// <summary>
            /// 掲載日(62)
            /// </summary>
            public const int Sybt2Cd    = 62; //掲載日 

            /// <summary>
            /// 印刷代(63)
            /// </summary>
            public const int SpaceCd    = 63; //印刷代 

            /// <summary>
            /// 差替作業料(64)
            /// </summary>
            public const int SpaceName  = 64; //差替作業料 

        }

        /// <summary>
        /// スプレッド背景色 
        /// </summary>
        public struct SpreadBackColor
        {
            /// <summary>
            /// 背景色：白色.
            /// </summary>
            public static readonly Color C_BACK_COLOR_WHITE = Color.White;
            /// <summary>
            /// 背景色：黄色.
            /// </summary>
            public static readonly Color C_BACK_COLOR_LYELLOW = Color.LightYellow;
            /// <summary>
            /// 背景色：薄いピンク.
            /// </summary>
//          public static readonly Color C_BACK_COLOR_MROSE = Color.MistyRose;
            public static readonly Color C_BACK_COLOR_MROSE = Color.FromArgb(255, 255, 102, 0);
            /// <summary>
            /// 背景色：赤色.
            /// </summary>
//          public static readonly Color C_BACK_COLOR_LPINK = Color.LightPink;
            public static readonly Color C_BACK_COLOR_LPINK = Color.FromArgb(255, 255, 128, 128);

            /// <summary>
            /// 背景色：水色.
            /// </summary>
            public static readonly Color C_BACK_COLOR_PBLUE = Color.PowderBlue;
            /// <summary>
            /// 背景色：灰色.
            /// </summary>
            public static readonly Color C_BACK_COLOR_LGRAY = Color.LightGray;
            /// <summary>
            /// 背景色：灰色.
            /// </summary>
//          public static readonly Color C_BACK_COLOR_DGRAY = Color.DarkGray;
            public static readonly Color C_BACK_COLOR_DGRAY = Color.FromArgb(255, 192, 192, 192);
        }

        /// <summary>
        /// 
        /// </summary>
        public struct SyuBetuID
        {
            /// <summary>
            /// 新聞 
            /// </summary>
            public const string ID_SHINBUN = "02";

            /// <summary>
            /// 雑誌  
            /// </summary>
            public const string ID_ZASHI = "03";

            /// <summary>
            /// テレビ 
            /// </summary>
            public const string ID_TV = "04";

            /// <summary>
            /// ラジオ
            /// </summary>
            public const string ID_RADIO = "05";

            /// <summary>
            /// 交通 
            /// </summary>
            public const string ID_OOH = "06";

            /// <summary>
            /// 衛星メディア 
            /// </summary>
            public const string ID_EISEI = "07";

            /// <summary>
            /// その他 
            /// </summary>
            public const string ID_SONOTA = "10";
        }
        #endregion
    }
}

package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 請求回収条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class RepaVbjaMeu16Skukjk {

    /**
     * インスタンス生成禁止
     */
    private RepaVbjaMeu16Skukjk() {
    }

    /** 請求回収条件 (REP_VBJ_MEU16SKUKJK) */
    public static final String TBNAME = "REP_VBJ_MEU16SKUKJK";

    /** Prefix (REP_V_) */
    public static final String PREFIX = "VEU_BJ_MEU16_";

    /** 取引先企業コード (THSKGYCD) */
    public static final String THSKGYCD = PREFIX + "THSKGYCD";

    /** ＳＥＱＮＯ (SEQNO) */
    public static final String SEQNO = PREFIX + "SEQNO";

    /** 取担当ＳＥＱＮＯ (TRTNTSEQNO) */
    public static final String TRTNTSEQNO = PREFIX + "TRTNTSEQNO";

    /** 有効終了年月日 (ENDYMD) */
    public static final String ENDYMD = PREFIX + "ENDYMD";

    /** 初期登録日時 (INSDATE) */
    public static final String INSDATE = PREFIX + "INSDATE";

    /** 初期登録担当者コード (INSTNTCD) */
    public static final String INSTNTCD = PREFIX + "INSTNTCD";

    /** 初期登録アプリＩＤ (INSAPLID) */
    public static final String INSAPLID = PREFIX + "INSAPLID";

    /** 最終更新日時 (UPDAPLDATE) */
    public static final String UPDAPLDATE = PREFIX + "UPDAPLDATE";

    /** 最終更新担当者コード (UPDTNTCD) */
    public static final String UPDTNTCD = PREFIX + "UPDTNTCD";

    /** 最終更新オンラインアプリＩＤ (UPDONLAPLID) */
    public static final String UPDONLAPLID = PREFIX + "UPDONLAPLID";

    /** 最終更新バッチアプリＩＤ (UPDBATAPLID) */
    public static final String UPDBATAPLID = PREFIX + "UPDBATAPLID";

    /** 有効開始年月日 (STARTYMD) */
    public static final String STARTYMD = PREFIX + "STARTYMD";

    /** 申請者コード (SNSTNT) */
    public static final String SNSTNT = PREFIX + "SNSTNT";

    /** 営業所コード (EGSYOCD) */
    public static final String EGSYOCD = PREFIX + "EGSYOCD";

    /** 信用条件更新年月日 (SINUPDYMD) */
    public static final String SINUPDYMD = PREFIX + "SINUPDYMD";

    /** 信用コード (SINCD) */
    public static final String SINCD = PREFIX + "SINCD";

    /** 信用限度額 (SINGND) */
    public static final String SINGND = PREFIX + "SINGND";

    /** 請求条件更新年月日 (SKUPDYMD) */
    public static final String SKUPDYMD = PREFIX + "SKUPDYMD";

    /** 計算担当 (SKKSNTNT) */
    public static final String SKKSNTNT = PREFIX + "SKKSNTNT";

    /** 請求書締日 (SKSMDAY) */
    public static final String SKSMDAY = PREFIX + "SKSMDAY";

    /** 請求書届日 (SKTDKDAY) */
    public static final String SKTDKDAY = PREFIX + "SKTDKDAY";

    /** 請求書発行日 (SKHKDAY) */
    public static final String SKHKDAY = PREFIX + "SKHKDAY";

    /** 回収条件更新年月日 (KSUPDYMD) */
    public static final String KSUPDYMD = PREFIX + "KSUPDYMD";

    /** 回収担当 (KSTNT) */
    public static final String KSTNT = PREFIX + "KSTNT";

    /** 回収予定日 (KSYOTEIDAY) */
    public static final String KSYOTEIDAY = PREFIX + "KSYOTEIDAY";

    /** 手数料負担 (KSTSURYO) */
    public static final String KSTSURYO = PREFIX + "KSTSURYO";

    /** 分割区分（１） (BNKTKBN1) */
    public static final String BNKTKBN1 = PREFIX + "BNKTKBN1";

    /** 優先順位（１．１） (YSN11) */
    public static final String YSN11 = PREFIX + "YSN11";

    /** 上限額（１．１） (JGNGAK11) */
    public static final String JGNGAK11 = PREFIX + "JGNGAK11";

    /** 金種（１．１） (KNS11) */
    public static final String KNS11 = PREFIX + "KNS11";

    /** サイト（１．１） (SITE11) */
    public static final String SITE11 = PREFIX + "SITE11";

    /** 優先順位（１．２） (YSN12) */
    public static final String YSN12 = PREFIX + "YSN12";

    /** 上限額（１．２） (JGNGAK12) */
    public static final String JGNGAK12 = PREFIX + "JGNGAK12";

    /** 金種（１．２） (KNS12) */
    public static final String KNS12 = PREFIX + "KNS12";

    /** サイト（１．２） (SITE12) */
    public static final String SITE12 = PREFIX + "SITE12";

    /** 比率（１．１） (HRT11) */
    public static final String HRT11 = PREFIX + "HRT11";

    /** 比率（１．２） (HRT12) */
    public static final String HRT12 = PREFIX + "HRT12";

    /** 分割区分（２） (BNKTKBN2) */
    public static final String BNKTKBN2 = PREFIX + "BNKTKBN2";

    /** 優先順位（２．１） (YSN21) */
    public static final String YSN21 = PREFIX + "YSN21";

    /** 上限額（２．１） (JGNGAK21) */
    public static final String JGNGAK21 = PREFIX + "JGNGAK21";

    /** 金種（２．１） (KNS21) */
    public static final String KNS21 = PREFIX + "KNS21";

    /** サイト（２．１） (SITE21) */
    public static final String SITE21 = PREFIX + "SITE21";

    /** 優先順位（２．２） (YSN22) */
    public static final String YSN22 = PREFIX + "YSN22";

    /** 上限額（２．２） (JGNGAK22) */
    public static final String JGNGAK22 = PREFIX + "JGNGAK22";

    /** 金種（２．２） (KNS22) */
    public static final String KNS22 = PREFIX + "KNS22";

    /** サイト（２．２） (SITE22) */
    public static final String SITE22 = PREFIX + "SITE22";

    /** 比率（２．１） (HRT21) */
    public static final String HRT21 = PREFIX + "HRT21";

    /** 比率（２．２） (HRT22) */
    public static final String HRT22 = PREFIX + "HRT22";

    /** 郵便番号 (POST) */
    public static final String POST = PREFIX + "POST";

    /** 住所 (ADDRESS) */
    public static final String ADDRESS = PREFIX + "ADDRESS";

    /** 部署名 (BUSYO) */
    public static final String BUSYO = PREFIX + "BUSYO";

    /** 電話番号 (TEL) */
    public static final String TEL = PREFIX + "TEL";

    /** 信用コード期限 (SKIGEN) */
    public static final String SKIGEN = PREFIX + "SKIGEN";

}

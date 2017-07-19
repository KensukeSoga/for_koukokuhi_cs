package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 見積明細
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj06EstimateDetail {

    /**
     * インスタンス生成禁止
     */
    private Tbj06EstimateDetail() {
    }

    /** 見積明細 (TBJ06ESTIMATEDETAIL) */
    public static final String TBNAME = "TBJ06ESTIMATEDETAIL";

    /** Prefix (TBJ06_) */
    public static final String PREFIX = "TBJ06_";

    /** 見積明細管理NO (ESTDETAILSEQNO) */
    public static final String ESTDETAILSEQNO = PREFIX + "ESTDETAILSEQNO";

    /** フェイズ (PHASE) */
    public static final String PHASE = PREFIX + "PHASE";

    /** 年月 (CRDATE) */
    public static final String CRDATE = PREFIX + "CRDATE";

    /** 見積案件管理NO (ESTSEQNO) */
    public static final String ESTSEQNO = PREFIX + "ESTSEQNO";

    /** ソート順 (SORTNO) */
    public static final String SORTNO = PREFIX + "SORTNO";

    /** 商品コード (PRODUCTCD) */
    public static final String PRODUCTCD = PREFIX + "PRODUCTCD";

    /** 商品名 (PRODUCTNM) */
    public static final String PRODUCTNM = PREFIX + "PRODUCTNM";

    /** 商品名(サブ） (PRODUCTNMSUB) */
    public static final String PRODUCTNMSUB = PREFIX + "PRODUCTNMSUB";

    /** 媒体分類コード (MEDIACLASSCD) */
    public static final String MEDIACLASSCD = PREFIX + "MEDIACLASSCD";

    /** 媒体コード (MEDIACD) */
    public static final String MEDIACD = PREFIX + "MEDIACD";

    /** 業務分類コード (BUSINESSCLASSCD) */
    public static final String BUSINESSCLASSCD = PREFIX + "BUSINESSCLASSCD";

    /** 業務コード (BUSINESSCD) */
    public static final String BUSINESSCD = PREFIX + "BUSINESSCD";

    /** 摘要 (TEKIYOU) */
    public static final String TEKIYOU = PREFIX + "TEKIYOU";

    /** 実施日 (OPERATIONDATE) */
    public static final String OPERATIONDATE = PREFIX + "OPERATIONDATE";

    /** サイズコード (SIZECD) */
    public static final String SIZECD = PREFIX + "SIZECD";

    /** サイズ (SIZE) */
    public static final String SIZE = PREFIX + "SIZE";

    /** 数量 (SUURYOU) */
    public static final String SUURYOU = PREFIX + "SUURYOU";

    /** 単位グループコード (UNITGROUPCD) */
    public static final String UNITGROUPCD = PREFIX + "UNITGROUPCD";

    /** 単位グループ名 (UNITGROUPNM) */
    public static final String UNITGROUPNM = PREFIX + "UNITGROUPNM";

    /** 単価 (TANKA) */
    public static final String TANKA = PREFIX + "TANKA";

    /** 標準金額 (HYOUJUN) */
    public static final String HYOUJUN = PREFIX + "HYOUJUN";

    /** 値引額 (NEBIKI) */
    public static final String NEBIKI = PREFIX + "NEBIKI";

    /** 見積金額 (MITUMORI) */
    public static final String MITUMORI = PREFIX + "MITUMORI";

    /** 課税対象額 (KAZEI) */
    public static final String KAZEI = PREFIX + "KAZEI";

    /** 消費税額 (SYOUHIZEI) */
    public static final String SYOUHIZEI = PREFIX + "SYOUHIZEI";

    /** 合計金額 (GOUKEI) */
    public static final String GOUKEI = PREFIX + "GOUKEI";

    /** 仕入消費税計算区分 (CALKBN) */
    public static final String CALKBN = PREFIX + "CALKBN";

    /** 納入フラグ (NOUNYUUFLG) */
    public static final String NOUNYUUFLG = PREFIX + "NOUNYUUFLG";

    /** 出来高フラグ (DEKIDAKAFLG) */
    public static final String DEKIDAKAFLG = PREFIX + "DEKIDAKAFLG";

    /** 出力グループ (OUTPUTGROUP) */
    public static final String OUTPUTGROUP = PREFIX + "OUTPUTGROUP";

    /** 請求先グループ (HCBUMONCDBILL) */
    public static final String HCBUMONCDBILL = PREFIX + "HCBUMONCDBILL";

    /** 請求先グループ出力順SEQNO (HCBUMONCDBILLSEQNO) */
    public static final String HCBUMONCDBILLSEQNO = PREFIX + "HCBUMONCDBILLSEQNO";

    /** データ作成日時 (CRTDATE) */
    public static final String CRTDATE = PREFIX + "CRTDATE";

    /** データ作成者 (CRTNM) */
    public static final String CRTNM = PREFIX + "CRTNM";

    /** 作成プログラム (CRTAPL) */
    public static final String CRTAPL = PREFIX + "CRTAPL";

    /** 作成担当者ID (CRTID) */
    public static final String CRTID = PREFIX + "CRTID";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}

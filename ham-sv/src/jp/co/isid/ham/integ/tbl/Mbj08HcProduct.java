package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * HC商品マスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj08HcProduct {

    /**
     * インスタンス生成禁止
     */
    private Mbj08HcProduct() {
    }

    /** HC商品マスタ (MBJ08HCPRODUCT) */
    public static final String TBNAME = "MBJ08HCPRODUCT";

    /** Prefix (MBJ08_) */
    public static final String PREFIX = "MBJ08_";

    /** HC商品コード (HCPRODUCTCD) */
    public static final String HCPRODUCTCD = PREFIX + "HCPRODUCTCD";

    /** 使用部門コード (USEBUMONCD) */
    public static final String USEBUMONCD = PREFIX + "USEBUMONCD";

    /** 使用部門名 (USEBUMONNM) */
    public static final String USEBUMONNM = PREFIX + "USEBUMONNM";

    /** 媒体分類コード (MEDIACLASSCD) */
    public static final String MEDIACLASSCD = PREFIX + "MEDIACLASSCD";

    /** 媒体分類名 (MEDIACLASSNM) */
    public static final String MEDIACLASSNM = PREFIX + "MEDIACLASSNM";

    /** 媒体コード (MEDIACD) */
    public static final String MEDIACD = PREFIX + "MEDIACD";

    /** 媒体名 (MEDIANM) */
    public static final String MEDIANM = PREFIX + "MEDIANM";

    /** 業務分類コード (BUSINESSCLASSCD) */
    public static final String BUSINESSCLASSCD = PREFIX + "BUSINESSCLASSCD";

    /** 業務分類名 (BUSINESSCLASSNM) */
    public static final String BUSINESSCLASSNM = PREFIX + "BUSINESSCLASSNM";

    /** 業務コード (BUSINESSCD) */
    public static final String BUSINESSCD = PREFIX + "BUSINESSCD";

    /** 業務名 (BUSINESSNM) */
    public static final String BUSINESSNM = PREFIX + "BUSINESSNM";

    /** 商品コード (PRODUCTCD) */
    public static final String PRODUCTCD = PREFIX + "PRODUCTCD";

    /** 商品名 (PRODUCTNM) */
    public static final String PRODUCTNM = PREFIX + "PRODUCTNM";

    /** 週コード (WEEKCD) */
    public static final String WEEKCD = PREFIX + "WEEKCD";

    /** 週 (WEEK) */
    public static final String WEEK = PREFIX + "WEEK";

    /** サイズコード (SIZECD) */
    public static final String SIZECD = PREFIX + "SIZECD";

    /** サイズ (SIZE) */
    public static final String SIZE = PREFIX + "SIZE";

    /** 単位グループコード (UNITGROUPCD) */
    public static final String UNITGROUPCD = PREFIX + "UNITGROUPCD";

    /** 単位グループ名 (UNITGROUPNM) */
    public static final String UNITGROUPNM = PREFIX + "UNITGROUPNM";

    /** 仕入消費税計算区分 (CALKBN) */
    public static final String CALKBN = PREFIX + "CALKBN";

    /** データ更新日時 (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** データ更新者 (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}

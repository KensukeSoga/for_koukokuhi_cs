package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 稼働ログ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj28WorkLog {

    /**
     * インスタンス生成禁止
     */
    private Tbj28WorkLog() {
    }

    /** 稼働ログ (TBJ28WORKLOG) */
    public static final String TBNAME = "TBJ28WORKLOG";

    /** Prefix (TBJ28_) */
    public static final String PREFIX = "TBJ28_";

    /** データ作成日時 (CRTDATE) */
    public static final String CRTDATE = PREFIX + "CRTDATE";

    /** 担当者ID(ESQID) (HAMID) */
    public static final String HAMID = PREFIX + "HAMID";

    /** 担当者名 (HAMNM) */
    public static final String HAMNM = PREFIX + "HAMNM";

    /** 組織コード（本部） (SIKCDHONB) */
    public static final String SIKCDHONB = PREFIX + "SIKCDHONB";

    /** 本部表示名（漢字） (SIKNMHONB) */
    public static final String SIKNMHONB = PREFIX + "SIKNMHONB";

    /** 組織コード（局） (SIKCDKYK) */
    public static final String SIKCDKYK = PREFIX + "SIKCDKYK";

    /** 局表示名（漢字） (SIKNMKYK) */
    public static final String SIKNMKYK = PREFIX + "SIKNMKYK";

    /** 組織コード（室） (SIKCDSITU) */
    public static final String SIKCDSITU = PREFIX + "SIKCDSITU";

    /** 室表示名（漢字） (SIKNMSITU) */
    public static final String SIKNMSITU = PREFIX + "SIKNMSITU";

    /** 組織コード（部） (SIKCDBU) */
    public static final String SIKCDBU = PREFIX + "SIKCDBU";

    /** 部表示名（漢字） (SIKNMBU) */
    public static final String SIKNMBU = PREFIX + "SIKNMBU";

    /** 組織コード（課） (SIKCDKA) */
    public static final String SIKCDKA = PREFIX + "SIKCDKA";

    /** 課表示名（漢字） (SIKNMKA) */
    public static final String SIKNMKA = PREFIX + "SIKNMKA";

    /** 画面ID (FORMID) */
    public static final String FORMID = PREFIX + "FORMID";

    /** 画面名 (FORMNM) */
    public static final String FORMNM = PREFIX + "FORMNM";

    /** 機能ID (KNOID) */
    public static final String KNOID = PREFIX + "KNOID";

    /** 機能名 (KNONM) */
    public static final String KNONM = PREFIX + "KNONM";

    /** 操作ID (DSMID) */
    public static final String DSMID = PREFIX + "DSMID";

    /** 操作名 (DSMNM) */
    public static final String DSMNM = PREFIX + "DSMNM";

}

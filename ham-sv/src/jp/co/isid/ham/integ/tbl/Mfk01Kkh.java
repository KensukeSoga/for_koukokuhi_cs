package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * 公開範囲マスタ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mfk01Kkh {

    /**
     * インスタンス生成禁止
     */
    private Mfk01Kkh() {
    }

    /** 公開範囲マスタ (MFK01KKH) */
    public static final String TBNAME = "MFK01KKH";

    /** Prefix (MFK01_) */
    public static final String PREFIX = "MFK01_";

    /** タイムスタンプ (TIMSTMP) */
    public static final String TIMSTMP = PREFIX + "TIMSTMP";

    /** 更新プログラム (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** 更新担当者 (UPDTNT) */
    public static final String UPDTNT = PREFIX + "UPDTNT";

    /** ユニットNo. (ZSBCH0100) */
    public static final String ZSBCH0100 = PREFIX + "ZSBCH0100";

    /** 有効終了日 (DATETO) */
    public static final String DATETO = PREFIX + "DATETO";

    /** 有効開始日 (DATEFROM) */
    public static final String DATEFROM = PREFIX + "DATEFROM";

    /** 組織コード (ZSBCH0105) */
    public static final String ZSBCH0105 = PREFIX + "ZSBCH0105";

    /** 範囲フラグ (ZHANNIGF) */
    public static final String ZHANNIGF = PREFIX + "ZHANNIGF";

    /** 担当グループ (ZSBCH0109) */
    public static final String ZSBCH0109 = PREFIX + "ZSBCH0109";

    /** 職位・等級グループ (ZTOUKYU) */
    public static final String ZTOUKYU = PREFIX + "ZTOUKYU";

    /** 社員コード (ZSBCH0110) */
    public static final String ZSBCH0110 = PREFIX + "ZSBCH0110";

    /** 予算科目（大分類） (ZBACCTL) */
    public static final String ZBACCTL = PREFIX + "ZBACCTL";

    /** 予算科目(中分類） (ZBACCTM) */
    public static final String ZBACCTM = PREFIX + "ZBACCTM";

    /** 予算科目(小分類） (ZBACCTS) */
    public static final String ZBACCTS = PREFIX + "ZBACCTS";

    /** 営業費登録可フラグ (ZEIGYOU) */
    public static final String ZEIGYOU = PREFIX + "ZEIGYOU";

    /** ＴＲＳ登録可フラグ (ZTRSFG) */
    public static final String ZTRSFG = PREFIX + "ZTRSFG";

    /** PL照会フラグ (ZPLFG) */
    public static final String ZPLFG = PREFIX + "ZPLFG";

    /** 受発注登録可フラグ (ZJYUHACHU) */
    public static final String ZJYUHACHU = PREFIX + "ZJYUHACHU";

    /** 全権限フラグ (ZALLFG) */
    public static final String ZALLFG = PREFIX + "ZALLFG";

    /** 継承管理フラグ (ZKEISYOU) */
    public static final String ZKEISYOU = PREFIX + "ZKEISYOU";

    /** 論理削除フラグ (ZDELFG) */
    public static final String ZDELFG = PREFIX + "ZDELFG";

    /** 公開範囲タイムスタンプ (KKHTIMESTAMP) */
    public static final String KKHTIMESTAMP = PREFIX + "KKHTIMESTAMP";

}

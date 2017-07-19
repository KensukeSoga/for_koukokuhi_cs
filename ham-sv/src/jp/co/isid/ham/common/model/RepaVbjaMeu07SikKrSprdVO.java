package jp.co.isid.ham.common.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu07SikKrSprd;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 経理組織展開テーブルVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu07SikKrSprdVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu07SikKrSprdVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new RepaVbjaMeu07SikKrSprdVO();
    }

    /**
     * 組織コードを取得する
     *
     * @return 組織コード
     */
    public String getSIKCD() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SIKCD);
    }

    /**
     * 組織コードを設定する
     *
     * @param val 組織コード
     */
    public void setSIKCD(String val) {
        set(RepaVbjaMeu07SikKrSprd.SIKCD, val);
    }

    /**
     * 有効終了年月日を取得する
     *
     * @return 有効終了年月日
     */
    public String getENDYMD() {
        return (String) get(RepaVbjaMeu07SikKrSprd.ENDYMD);
    }

    /**
     * 有効終了年月日を設定する
     *
     * @param val 有効終了年月日
     */
    public void setENDYMD(String val) {
        set(RepaVbjaMeu07SikKrSprd.ENDYMD, val);
    }

    /**
     * 有効開始年月日を取得する
     *
     * @return 有効開始年月日
     */
    public String getSTARTYMD() {
        return (String) get(RepaVbjaMeu07SikKrSprd.STARTYMD);
    }

    /**
     * 有効開始年月日を設定する
     *
     * @param val 有効開始年月日
     */
    public void setSTARTYMD(String val) {
        set(RepaVbjaMeu07SikKrSprd.STARTYMD, val);
    }

    /**
     * 経理階層コードを取得する
     *
     * @return 経理階層コード
     */
    public String getKRIKAISOCD() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KRIKAISOCD);
    }

    /**
     * 経理階層コードを設定する
     *
     * @param val 経理階層コード
     */
    public void setKRIKAISOCD(String val) {
        set(RepaVbjaMeu07SikKrSprd.KRIKAISOCD, val);
    }

    /**
     * 経理上位組織コードを取得する
     *
     * @return 経理上位組織コード
     */
    public String getKRIJSIKCD() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KRIJSIKCD);
    }

    /**
     * 経理上位組織コードを設定する
     *
     * @param val 経理上位組織コード
     */
    public void setKRIJSIKCD(String val) {
        set(RepaVbjaMeu07SikKrSprd.KRIJSIKCD, val);
    }

    /**
     * 直轄区分を取得する
     *
     * @return 直轄区分
     */
    public String getCKATUKBN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.CKATUKBN);
    }

    /**
     * 直轄区分を設定する
     *
     * @param val 直轄区分
     */
    public void setCKATUKBN(String val) {
        set(RepaVbjaMeu07SikKrSprd.CKATUKBN, val);
    }

    /**
     * 受注登録区分を取得する
     *
     * @return 受注登録区分
     */
    public String getJYTRKKBN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.JYTRKKBN);
    }

    /**
     * 受注登録区分を設定する
     *
     * @param val 受注登録区分
     */
    public void setJYTRKKBN(String val) {
        set(RepaVbjaMeu07SikKrSprd.JYTRKKBN, val);
    }

    /**
     * 発注登録区分を取得する
     *
     * @return 発注登録区分
     */
    public String getODRTRKKBN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.ODRTRKKBN);
    }

    /**
     * 発注登録区分を設定する
     *
     * @param val 発注登録区分
     */
    public void setODRTRKKBN(String val) {
        set(RepaVbjaMeu07SikKrSprd.ODRTRKKBN, val);
    }

    /**
     * 管理部門を取得する
     *
     * @return 管理部門
     */
    public String getKNRIBMON() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KNRIBMON);
    }

    /**
     * 管理部門を設定する
     *
     * @param val 管理部門
     */
    public void setKNRIBMON(String val) {
        set(RepaVbjaMeu07SikKrSprd.KNRIBMON, val);
    }

    /**
     * 会社取引先コードを取得する
     *
     * @return 会社取引先コード
     */
    public String getKSHATHSCD() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KSHATHSCD);
    }

    /**
     * 会社取引先コードを設定する
     *
     * @param val 会社取引先コード
     */
    public void setKSHATHSCD(String val) {
        set(RepaVbjaMeu07SikKrSprd.KSHATHSCD, val);
    }

    /**
     * 会社取引先ＳＥＱＮＯを取得する
     *
     * @return 会社取引先ＳＥＱＮＯ
     */
    public String getKSHATHSSEQNO() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KSHATHSSEQNO);
    }

    /**
     * 会社取引先ＳＥＱＮＯを設定する
     *
     * @param val 会社取引先ＳＥＱＮＯ
     */
    public void setKSHATHSSEQNO(String val) {
        set(RepaVbjaMeu07SikKrSprd.KSHATHSSEQNO, val);
    }

    /**
     * 旧取引先コードを取得する
     *
     * @return 旧取引先コード
     */
    public String getKYUTRCD() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KYUTRCD);
    }

    /**
     * 旧取引先コードを設定する
     *
     * @param val 旧取引先コード
     */
    public void setKYUTRCD(String val) {
        set(RepaVbjaMeu07SikKrSprd.KYUTRCD, val);
    }

    /**
     * 媒直区分を取得する
     *
     * @return 媒直区分
     */
    public String getBCKKBN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.BCKKBN);
    }

    /**
     * 媒直区分を設定する
     *
     * @param val 媒直区分
     */
    public void setBCKKBN(String val) {
        set(RepaVbjaMeu07SikKrSprd.BCKKBN, val);
    }

    /**
     * 営業所コードを取得する
     *
     * @return 営業所コード
     */
    public String getEGSYOCD() {
        return (String) get(RepaVbjaMeu07SikKrSprd.EGSYOCD);
    }

    /**
     * 営業所コードを設定する
     *
     * @param val 営業所コード
     */
    public void setEGSYOCD(String val) {
        set(RepaVbjaMeu07SikKrSprd.EGSYOCD, val);
    }

    /**
     * 表示順を取得する
     *
     * @return 表示順
     */
    public String getSHOWNO() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SHOWNO);
    }

    /**
     * 表示順を設定する
     *
     * @param val 表示順
     */
    public void setSHOWNO(String val) {
        set(RepaVbjaMeu07SikKrSprd.SHOWNO, val);
    }

    /**
     * 上位組織内表示順を取得する
     *
     * @return 上位組織内表示順
     */
    public String getJSIKHYOJIJUN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.JSIKHYOJIJUN);
    }

    /**
     * 上位組織内表示順を設定する
     *
     * @param val 上位組織内表示順
     */
    public void setJSIKHYOJIJUN(String val) {
        set(RepaVbjaMeu07SikKrSprd.JSIKHYOJIJUN, val);
    }

    /**
     * 表示名（カナ）を取得する
     *
     * @return 表示名（カナ）
     */
    public String getHYOJIKN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.HYOJIKN);
    }

    /**
     * 表示名（カナ）を設定する
     *
     * @param val 表示名（カナ）
     */
    public void setHYOJIKN(String val) {
        set(RepaVbjaMeu07SikKrSprd.HYOJIKN, val);
    }

    /**
     * 表示名（漢字）を取得する
     *
     * @return 表示名（漢字）
     */
    public String getHYOJIKJ() {
        return (String) get(RepaVbjaMeu07SikKrSprd.HYOJIKJ);
    }

    /**
     * 表示名（漢字）を設定する
     *
     * @param val 表示名（漢字）
     */
    public void setHYOJIKJ(String val) {
        set(RepaVbjaMeu07SikKrSprd.HYOJIKJ, val);
    }

    /**
     * 表示略称を取得する
     *
     * @return 表示略称
     */
    public String getHYOJIRYAKU() {
        return (String) get(RepaVbjaMeu07SikKrSprd.HYOJIRYAKU);
    }

    /**
     * 表示略称を設定する
     *
     * @param val 表示略称
     */
    public void setHYOJIRYAKU(String val) {
        set(RepaVbjaMeu07SikKrSprd.HYOJIRYAKU, val);
    }

    /**
     * 表示名（英字）を取得する
     *
     * @return 表示名（英字）
     */
    public String getHYOJIEN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.HYOJIEN);
    }

    /**
     * 表示名（英字）を設定する
     *
     * @param val 表示名（英字）
     */
    public void setHYOJIEN(String val) {
        set(RepaVbjaMeu07SikKrSprd.HYOJIEN, val);
    }

    /**
     * 会社識別コードを取得する
     *
     * @return 会社識別コード
     */
    public String getKSHASKBTUCD() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KSHASKBTUCD);
    }

    /**
     * 会社識別コードを設定する
     *
     * @param val 会社識別コード
     */
    public void setKSHASKBTUCD(String val) {
        set(RepaVbjaMeu07SikKrSprd.KSHASKBTUCD, val);
    }

    /**
     * 入出力コードを取得する
     *
     * @return 入出力コード
     */
    public String getIOCD() {
        return (String) get(RepaVbjaMeu07SikKrSprd.IOCD);
    }

    /**
     * 入出力コードを設定する
     *
     * @param val 入出力コード
     */
    public void setIOCD(String val) {
        set(RepaVbjaMeu07SikKrSprd.IOCD, val);
    }

    /**
     * 特殊用途コードを取得する
     *
     * @return 特殊用途コード
     */
    public String getSPUSECD() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SPUSECD);
    }

    /**
     * 特殊用途コードを設定する
     *
     * @param val 特殊用途コード
     */
    public void setSPUSECD(String val) {
        set(RepaVbjaMeu07SikKrSprd.SPUSECD, val);
    }

    /**
     * 組織コード（本部）を取得する
     *
     * @return 組織コード（本部）
     */
    public String getSIKCDHONB() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SIKCDHONB);
    }

    /**
     * 組織コード（本部）を設定する
     *
     * @param val 組織コード（本部）
     */
    public void setSIKCDHONB(String val) {
        set(RepaVbjaMeu07SikKrSprd.SIKCDHONB, val);
    }

    /**
     * 本部表示名（カナ）を取得する
     *
     * @return 本部表示名（カナ）
     */
    public String getHONBHYOJIKN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.HONBHYOJIKN);
    }

    /**
     * 本部表示名（カナ）を設定する
     *
     * @param val 本部表示名（カナ）
     */
    public void setHONBHYOJIKN(String val) {
        set(RepaVbjaMeu07SikKrSprd.HONBHYOJIKN, val);
    }

    /**
     * 本部表示名（漢字）を取得する
     *
     * @return 本部表示名（漢字）
     */
    public String getHONBHYOJIKJ() {
        return (String) get(RepaVbjaMeu07SikKrSprd.HONBHYOJIKJ);
    }

    /**
     * 本部表示名（漢字）を設定する
     *
     * @param val 本部表示名（漢字）
     */
    public void setHONBHYOJIKJ(String val) {
        set(RepaVbjaMeu07SikKrSprd.HONBHYOJIKJ, val);
    }

    /**
     * 本部表示略称を取得する
     *
     * @return 本部表示略称
     */
    public String getHONBHYOJIRYAKU() {
        return (String) get(RepaVbjaMeu07SikKrSprd.HONBHYOJIRYAKU);
    }

    /**
     * 本部表示略称を設定する
     *
     * @param val 本部表示略称
     */
    public void setHONBHYOJIRYAKU(String val) {
        set(RepaVbjaMeu07SikKrSprd.HONBHYOJIRYAKU, val);
    }

    /**
     * 本部表示名（英字）を取得する
     *
     * @return 本部表示名（英字）
     */
    public String getHONBHYOJIEN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.HONBHYOJIEN);
    }

    /**
     * 本部表示名（英字）を設定する
     *
     * @param val 本部表示名（英字）
     */
    public void setHONBHYOJIEN(String val) {
        set(RepaVbjaMeu07SikKrSprd.HONBHYOJIEN, val);
    }

    /**
     * 組織コード（局）を取得する
     *
     * @return 組織コード（局）
     */
    public String getSIKCDKYK() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SIKCDKYK);
    }

    /**
     * 組織コード（局）を設定する
     *
     * @param val 組織コード（局）
     */
    public void setSIKCDKYK(String val) {
        set(RepaVbjaMeu07SikKrSprd.SIKCDKYK, val);
    }

    /**
     * 局表示名（カナ）を取得する
     *
     * @return 局表示名（カナ）
     */
    public String getKYKHYOJIKN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KYKHYOJIKN);
    }

    /**
     * 局表示名（カナ）を設定する
     *
     * @param val 局表示名（カナ）
     */
    public void setKYKHYOJIKN(String val) {
        set(RepaVbjaMeu07SikKrSprd.KYKHYOJIKN, val);
    }

    /**
     * 局表示名（漢字）を取得する
     *
     * @return 局表示名（漢字）
     */
    public String getKYKHYOJIKJ() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KYKHYOJIKJ);
    }

    /**
     * 局表示名（漢字）を設定する
     *
     * @param val 局表示名（漢字）
     */
    public void setKYKHYOJIKJ(String val) {
        set(RepaVbjaMeu07SikKrSprd.KYKHYOJIKJ, val);
    }

    /**
     * 局表示略称を取得する
     *
     * @return 局表示略称
     */
    public String getKYKHYOJIRYAKU() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KYKHYOJIRYAKU);
    }

    /**
     * 局表示略称を設定する
     *
     * @param val 局表示略称
     */
    public void setKYKHYOJIRYAKU(String val) {
        set(RepaVbjaMeu07SikKrSprd.KYKHYOJIRYAKU, val);
    }

    /**
     * 局表示名（英字）を取得する
     *
     * @return 局表示名（英字）
     */
    public String getKYKHYOJIEN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KYKHYOJIEN);
    }

    /**
     * 局表示名（英字）を設定する
     *
     * @param val 局表示名（英字）
     */
    public void setKYKHYOJIEN(String val) {
        set(RepaVbjaMeu07SikKrSprd.KYKHYOJIEN, val);
    }

    /**
     * 組織コード（室）を取得する
     *
     * @return 組織コード（室）
     */
    public String getSIKCDSITU() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SIKCDSITU);
    }

    /**
     * 組織コード（室）を設定する
     *
     * @param val 組織コード（室）
     */
    public void setSIKCDSITU(String val) {
        set(RepaVbjaMeu07SikKrSprd.SIKCDSITU, val);
    }

    /**
     * 室表示名（カナ）を取得する
     *
     * @return 室表示名（カナ）
     */
    public String getSITUHYOJIKN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SITUHYOJIKN);
    }

    /**
     * 室表示名（カナ）を設定する
     *
     * @param val 室表示名（カナ）
     */
    public void setSITUHYOJIKN(String val) {
        set(RepaVbjaMeu07SikKrSprd.SITUHYOJIKN, val);
    }

    /**
     * 室表示名（漢字）を取得する
     *
     * @return 室表示名（漢字）
     */
    public String getSITUHYOJIKJ() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SITUHYOJIKJ);
    }

    /**
     * 室表示名（漢字）を設定する
     *
     * @param val 室表示名（漢字）
     */
    public void setSITUHYOJIKJ(String val) {
        set(RepaVbjaMeu07SikKrSprd.SITUHYOJIKJ, val);
    }

    /**
     * 室表示略称を取得する
     *
     * @return 室表示略称
     */
    public String getSITUHYOJIRYAKU() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SITUHYOJIRYAKU);
    }

    /**
     * 室表示略称を設定する
     *
     * @param val 室表示略称
     */
    public void setSITUHYOJIRYAKU(String val) {
        set(RepaVbjaMeu07SikKrSprd.SITUHYOJIRYAKU, val);
    }

    /**
     * 室表示名（英字）を取得する
     *
     * @return 室表示名（英字）
     */
    public String getSITUHYOJIEN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SITUHYOJIEN);
    }

    /**
     * 室表示名（英字）を設定する
     *
     * @param val 室表示名（英字）
     */
    public void setSITUHYOJIEN(String val) {
        set(RepaVbjaMeu07SikKrSprd.SITUHYOJIEN, val);
    }

    /**
     * 組織コード（部）を取得する
     *
     * @return 組織コード（部）
     */
    public String getSIKCDBU() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SIKCDBU);
    }

    /**
     * 組織コード（部）を設定する
     *
     * @param val 組織コード（部）
     */
    public void setSIKCDBU(String val) {
        set(RepaVbjaMeu07SikKrSprd.SIKCDBU, val);
    }

    /**
     * 部表示名（カナ）を取得する
     *
     * @return 部表示名（カナ）
     */
    public String getBUHYOJIKN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.BUHYOJIKN);
    }

    /**
     * 部表示名（カナ）を設定する
     *
     * @param val 部表示名（カナ）
     */
    public void setBUHYOJIKN(String val) {
        set(RepaVbjaMeu07SikKrSprd.BUHYOJIKN, val);
    }

    /**
     * 部表示名（漢字）を取得する
     *
     * @return 部表示名（漢字）
     */
    public String getBUHYOJIKJ() {
        return (String) get(RepaVbjaMeu07SikKrSprd.BUHYOJIKJ);
    }

    /**
     * 部表示名（漢字）を設定する
     *
     * @param val 部表示名（漢字）
     */
    public void setBUHYOJIKJ(String val) {
        set(RepaVbjaMeu07SikKrSprd.BUHYOJIKJ, val);
    }

    /**
     * 部表示略称を取得する
     *
     * @return 部表示略称
     */
    public String getBUHYOJIRYAKU() {
        return (String) get(RepaVbjaMeu07SikKrSprd.BUHYOJIRYAKU);
    }

    /**
     * 部表示略称を設定する
     *
     * @param val 部表示略称
     */
    public void setBUHYOJIRYAKU(String val) {
        set(RepaVbjaMeu07SikKrSprd.BUHYOJIRYAKU, val);
    }

    /**
     * 部表示名（英字）を取得する
     *
     * @return 部表示名（英字）
     */
    public String getBUHYOJIEN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.BUHYOJIEN);
    }

    /**
     * 部表示名（英字）を設定する
     *
     * @param val 部表示名（英字）
     */
    public void setBUHYOJIEN(String val) {
        set(RepaVbjaMeu07SikKrSprd.BUHYOJIEN, val);
    }

    /**
     * 組織コード（課）を取得する
     *
     * @return 組織コード（課）
     */
    public String getSIKCDKA() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SIKCDKA);
    }

    /**
     * 組織コード（課）を設定する
     *
     * @param val 組織コード（課）
     */
    public void setSIKCDKA(String val) {
        set(RepaVbjaMeu07SikKrSprd.SIKCDKA, val);
    }

    /**
     * 課表示名（カナ）を取得する
     *
     * @return 課表示名（カナ）
     */
    public String getKAHYOJIKN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KAHYOJIKN);
    }

    /**
     * 課表示名（カナ）を設定する
     *
     * @param val 課表示名（カナ）
     */
    public void setKAHYOJIKN(String val) {
        set(RepaVbjaMeu07SikKrSprd.KAHYOJIKN, val);
    }

    /**
     * 課表示名（漢字）を取得する
     *
     * @return 課表示名（漢字）
     */
    public String getKAHYOJIKJ() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KAHYOJIKJ);
    }

    /**
     * 課表示名（漢字）を設定する
     *
     * @param val 課表示名（漢字）
     */
    public void setKAHYOJIKJ(String val) {
        set(RepaVbjaMeu07SikKrSprd.KAHYOJIKJ, val);
    }

    /**
     * 課表示略称を取得する
     *
     * @return 課表示略称
     */
    public String getKAHYOJIRYAKU() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KAHYOJIRYAKU);
    }

    /**
     * 課表示略称を設定する
     *
     * @param val 課表示略称
     */
    public void setKAHYOJIRYAKU(String val) {
        set(RepaVbjaMeu07SikKrSprd.KAHYOJIRYAKU, val);
    }

    /**
     * 課表示名（英字）を取得する
     *
     * @return 課表示名（英字）
     */
    public String getKAHYOJIEN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KAHYOJIEN);
    }

    /**
     * 課表示名（英字）を設定する
     *
     * @param val 課表示名（英字）
     */
    public void setKAHYOJIEN(String val) {
        set(RepaVbjaMeu07SikKrSprd.KAHYOJIEN, val);
    }

}

package jp.co.isid.ham.common.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu00Sik;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 組織マスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu00SikVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu00SikVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new RepaVbjaMeu00SikVO();
    }

    /**
     * 組織コードを取得する
     *
     * @return 組織コード
     */
    public String getSIKCD() {
        return (String) get(RepaVbjaMeu00Sik.SIKCD);
    }

    /**
     * 組織コードを設定する
     *
     * @param val 組織コード
     */
    public void setSIKCD(String val) {
        set(RepaVbjaMeu00Sik.SIKCD, val);
    }

    /**
     * 有効終了年月日を取得する
     *
     * @return 有効終了年月日
     */
    public String getENDYMD() {
        return (String) get(RepaVbjaMeu00Sik.ENDYMD);
    }

    /**
     * 有効終了年月日を設定する
     *
     * @param val 有効終了年月日
     */
    public void setENDYMD(String val) {
        set(RepaVbjaMeu00Sik.ENDYMD, val);
    }

    /**
     * 初期登録日時を取得する
     *
     * @return 初期登録日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getINSDATE() {
        return (Date) get(RepaVbjaMeu00Sik.INSDATE);
    }

    /**
     * 初期登録日時を設定する
     *
     * @param val 初期登録日時
     */
    public void setINSDATE(Date val) {
        set(RepaVbjaMeu00Sik.INSDATE, val);
    }

    /**
     * 初期登録組織担当者コードを取得する
     *
     * @return 初期登録組織担当者コード
     */
    public String getINSSIKTNTCD() {
        return (String) get(RepaVbjaMeu00Sik.INSSIKTNTCD);
    }

    /**
     * 初期登録組織担当者コードを設定する
     *
     * @param val 初期登録組織担当者コード
     */
    public void setINSSIKTNTCD(String val) {
        set(RepaVbjaMeu00Sik.INSSIKTNTCD, val);
    }

    /**
     * 初期登録アプリＩＤを取得する
     *
     * @return 初期登録アプリＩＤ
     */
    public String getINSAPLID() {
        return (String) get(RepaVbjaMeu00Sik.INSAPLID);
    }

    /**
     * 初期登録アプリＩＤを設定する
     *
     * @param val 初期登録アプリＩＤ
     */
    public void setINSAPLID(String val) {
        set(RepaVbjaMeu00Sik.INSAPLID, val);
    }

    /**
     * 最終更新日時を取得する
     *
     * @return 最終更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDAPLDATE() {
        return (Date) get(RepaVbjaMeu00Sik.UPDAPLDATE);
    }

    /**
     * 最終更新日時を設定する
     *
     * @param val 最終更新日時
     */
    public void setUPDAPLDATE(Date val) {
        set(RepaVbjaMeu00Sik.UPDAPLDATE, val);
    }

    /**
     * 最終更新組織担当者コードを取得する
     *
     * @return 最終更新組織担当者コード
     */
    public String getUPDSIKTNTCD() {
        return (String) get(RepaVbjaMeu00Sik.UPDSIKTNTCD);
    }

    /**
     * 最終更新組織担当者コードを設定する
     *
     * @param val 最終更新組織担当者コード
     */
    public void setUPDSIKTNTCD(String val) {
        set(RepaVbjaMeu00Sik.UPDSIKTNTCD, val);
    }

    /**
     * 最終更新オンラインアプリＩＤを取得する
     *
     * @return 最終更新オンラインアプリＩＤ
     */
    public String getUPDONLAPLID() {
        return (String) get(RepaVbjaMeu00Sik.UPDONLAPLID);
    }

    /**
     * 最終更新オンラインアプリＩＤを設定する
     *
     * @param val 最終更新オンラインアプリＩＤ
     */
    public void setUPDONLAPLID(String val) {
        set(RepaVbjaMeu00Sik.UPDONLAPLID, val);
    }

    /**
     * 最終更新バッチアプリＩＤを取得する
     *
     * @return 最終更新バッチアプリＩＤ
     */
    public String getUPDBATAPLID() {
        return (String) get(RepaVbjaMeu00Sik.UPDBATAPLID);
    }

    /**
     * 最終更新バッチアプリＩＤを設定する
     *
     * @param val 最終更新バッチアプリＩＤ
     */
    public void setUPDBATAPLID(String val) {
        set(RepaVbjaMeu00Sik.UPDBATAPLID, val);
    }

    /**
     * 有効開始年月日を取得する
     *
     * @return 有効開始年月日
     */
    public String getSTARTYMD() {
        return (String) get(RepaVbjaMeu00Sik.STARTYMD);
    }

    /**
     * 有効開始年月日を設定する
     *
     * @param val 有効開始年月日
     */
    public void setSTARTYMD(String val) {
        set(RepaVbjaMeu00Sik.STARTYMD, val);
    }

    /**
     * 会社識別コードを取得する
     *
     * @return 会社識別コード
     */
    public String getKSHASKBTUCD() {
        return (String) get(RepaVbjaMeu00Sik.KSHASKBTUCD);
    }

    /**
     * 会社識別コードを設定する
     *
     * @param val 会社識別コード
     */
    public void setKSHASKBTUCD(String val) {
        set(RepaVbjaMeu00Sik.KSHASKBTUCD, val);
    }

    /**
     * 入出力コードを取得する
     *
     * @return 入出力コード
     */
    public String getIOCD() {
        return (String) get(RepaVbjaMeu00Sik.IOCD);
    }

    /**
     * 入出力コードを設定する
     *
     * @param val 入出力コード
     */
    public void setIOCD(String val) {
        set(RepaVbjaMeu00Sik.IOCD, val);
    }

    /**
     * 表示名（カナ）を取得する
     *
     * @return 表示名（カナ）
     */
    public String getHYOJIKN() {
        return (String) get(RepaVbjaMeu00Sik.HYOJIKN);
    }

    /**
     * 表示名（カナ）を設定する
     *
     * @param val 表示名（カナ）
     */
    public void setHYOJIKN(String val) {
        set(RepaVbjaMeu00Sik.HYOJIKN, val);
    }

    /**
     * 表示名（漢字）を取得する
     *
     * @return 表示名（漢字）
     */
    public String getHYOJIKJ() {
        return (String) get(RepaVbjaMeu00Sik.HYOJIKJ);
    }

    /**
     * 表示名（漢字）を設定する
     *
     * @param val 表示名（漢字）
     */
    public void setHYOJIKJ(String val) {
        set(RepaVbjaMeu00Sik.HYOJIKJ, val);
    }

    /**
     * 表示略称を取得する
     *
     * @return 表示略称
     */
    public String getHYOJIRYAKU() {
        return (String) get(RepaVbjaMeu00Sik.HYOJIRYAKU);
    }

    /**
     * 表示略称を設定する
     *
     * @param val 表示略称
     */
    public void setHYOJIRYAKU(String val) {
        set(RepaVbjaMeu00Sik.HYOJIRYAKU, val);
    }

    /**
     * 表示名（英字）を取得する
     *
     * @return 表示名（英字）
     */
    public String getHYOJIEN() {
        return (String) get(RepaVbjaMeu00Sik.HYOJIEN);
    }

    /**
     * 表示名（英字）を設定する
     *
     * @param val 表示名（英字）
     */
    public void setHYOJIEN(String val) {
        set(RepaVbjaMeu00Sik.HYOJIEN, val);
    }

    /**
     * 特殊用途コードを取得する
     *
     * @return 特殊用途コード
     */
    public String getSPUSECD() {
        return (String) get(RepaVbjaMeu00Sik.SPUSECD);
    }

    /**
     * 特殊用途コードを設定する
     *
     * @param val 特殊用途コード
     */
    public void setSPUSECD(String val) {
        set(RepaVbjaMeu00Sik.SPUSECD, val);
    }

    /**
     * 階層コードを取得する
     *
     * @return 階層コード
     */
    public String getKAISOCD() {
        return (String) get(RepaVbjaMeu00Sik.KAISOCD);
    }

    /**
     * 階層コードを設定する
     *
     * @param val 階層コード
     */
    public void setKAISOCD(String val) {
        set(RepaVbjaMeu00Sik.KAISOCD, val);
    }

    /**
     * 上位組織コードを取得する
     *
     * @return 上位組織コード
     */
    public String getJSIKCD() {
        return (String) get(RepaVbjaMeu00Sik.JSIKCD);
    }

    /**
     * 上位組織コードを設定する
     *
     * @param val 上位組織コード
     */
    public void setJSIKCD(String val) {
        set(RepaVbjaMeu00Sik.JSIKCD, val);
    }

    /**
     * 直轄区分を取得する
     *
     * @return 直轄区分
     */
    public String getCKATUKBN() {
        return (String) get(RepaVbjaMeu00Sik.CKATUKBN);
    }

    /**
     * 直轄区分を設定する
     *
     * @param val 直轄区分
     */
    public void setCKATUKBN(String val) {
        set(RepaVbjaMeu00Sik.CKATUKBN, val);
    }

    /**
     * 受注登録区分を取得する
     *
     * @return 受注登録区分
     */
    public String getJYTRKKBN() {
        return (String) get(RepaVbjaMeu00Sik.JYTRKKBN);
    }

    /**
     * 受注登録区分を設定する
     *
     * @param val 受注登録区分
     */
    public void setJYTRKKBN(String val) {
        set(RepaVbjaMeu00Sik.JYTRKKBN, val);
    }

    /**
     * 発注登録区分を取得する
     *
     * @return 発注登録区分
     */
    public String getODRTRKKBN() {
        return (String) get(RepaVbjaMeu00Sik.ODRTRKKBN);
    }

    /**
     * 発注登録区分を設定する
     *
     * @param val 発注登録区分
     */
    public void setODRTRKKBN(String val) {
        set(RepaVbjaMeu00Sik.ODRTRKKBN, val);
    }

    /**
     * 管理部門を取得する
     *
     * @return 管理部門
     */
    public String getKNRIBMON() {
        return (String) get(RepaVbjaMeu00Sik.KNRIBMON);
    }

    /**
     * 管理部門を設定する
     *
     * @param val 管理部門
     */
    public void setKNRIBMON(String val) {
        set(RepaVbjaMeu00Sik.KNRIBMON, val);
    }

    /**
     * 会社取引先企業コードを取得する
     *
     * @return 会社取引先企業コード
     */
    public String getKSHATHSKGYCD() {
        return (String) get(RepaVbjaMeu00Sik.KSHATHSKGYCD);
    }

    /**
     * 会社取引先企業コードを設定する
     *
     * @param val 会社取引先企業コード
     */
    public void setKSHATHSKGYCD(String val) {
        set(RepaVbjaMeu00Sik.KSHATHSKGYCD, val);
    }

    /**
     * 会社取引先ＳＥＱＮＯを取得する
     *
     * @return 会社取引先ＳＥＱＮＯ
     */
    public String getKSHATHSSEQNO() {
        return (String) get(RepaVbjaMeu00Sik.KSHATHSSEQNO);
    }

    /**
     * 会社取引先ＳＥＱＮＯを設定する
     *
     * @param val 会社取引先ＳＥＱＮＯ
     */
    public void setKSHATHSSEQNO(String val) {
        set(RepaVbjaMeu00Sik.KSHATHSSEQNO, val);
    }

    /**
     * 旧会社取引先コードを取得する
     *
     * @return 旧会社取引先コード
     */
    public String getKYUKSHATHSCD() {
        return (String) get(RepaVbjaMeu00Sik.KYUKSHATHSCD);
    }

    /**
     * 旧会社取引先コードを設定する
     *
     * @param val 旧会社取引先コード
     */
    public void setKYUKSHATHSCD(String val) {
        set(RepaVbjaMeu00Sik.KYUKSHATHSCD, val);
    }

    /**
     * 媒直区分を取得する
     *
     * @return 媒直区分
     */
    public String getBCKKBN() {
        return (String) get(RepaVbjaMeu00Sik.BCKKBN);
    }

    /**
     * 媒直区分を設定する
     *
     * @param val 媒直区分
     */
    public void setBCKKBN(String val) {
        set(RepaVbjaMeu00Sik.BCKKBN, val);
    }

    /**
     * 営業所コードを取得する
     *
     * @return 営業所コード
     */
    public String getEGSYOCD() {
        return (String) get(RepaVbjaMeu00Sik.EGSYOCD);
    }

    /**
     * 営業所コードを設定する
     *
     * @param val 営業所コード
     */
    public void setEGSYOCD(String val) {
        set(RepaVbjaMeu00Sik.EGSYOCD, val);
    }

    /**
     * 広告主別Ｐ／Ｌ部門種別を取得する
     *
     * @return 広告主別Ｐ／Ｌ部門種別
     */
    public String getCLNTPLBMNSBETU() {
        return (String) get(RepaVbjaMeu00Sik.CLNTPLBMNSBETU);
    }

    /**
     * 広告主別Ｐ／Ｌ部門種別を設定する
     *
     * @param val 広告主別Ｐ／Ｌ部門種別
     */
    public void setCLNTPLBMNSBETU(String val) {
        set(RepaVbjaMeu00Sik.CLNTPLBMNSBETU, val);
    }

}

package jp.co.isid.ham.common.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMea10Irsk;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 発注先マスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMea10IrskVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMea10IrskVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new RepaVbjaMea10IrskVO();
    }

    /**
     * IRSKCDを取得する
     *
     * @return IRSKCD
     */
    public String getIRSKCD() {
        return (String) get(RepaVbjaMea10Irsk.IRSKCD);
    }

    /**
     * IRSKCDを設定する
     *
     * @param val IRSKCD
     */
    public void setIRSKCD(String val) {
        set(RepaVbjaMea10Irsk.IRSKCD, val);
    }

    /**
     * IRSKSUBCDを取得する
     *
     * @return IRSKSUBCD
     */
    public String getIRSKSUBCD() {
        return (String) get(RepaVbjaMea10Irsk.IRSKSUBCD);
    }

    /**
     * IRSKSUBCDを設定する
     *
     * @param val IRSKSUBCD
     */
    public void setIRSKSUBCD(String val) {
        set(RepaVbjaMea10Irsk.IRSKSUBCD, val);
    }

    /**
     * IRSKALASHYOJIKNを取得する
     *
     * @return IRSKALASHYOJIKN
     */
    public String getIRSKALASHYOJIKN() {
        return (String) get(RepaVbjaMea10Irsk.IRSKALASHYOJIKN);
    }

    /**
     * IRSKALASHYOJIKNを設定する
     *
     * @param val IRSKALASHYOJIKN
     */
    public void setIRSKALASHYOJIKN(String val) {
        set(RepaVbjaMea10Irsk.IRSKALASHYOJIKN, val);
    }

    /**
     * IRSKALASHYOJIKJを取得する
     *
     * @return IRSKALASHYOJIKJ
     */
    public String getIRSKALASHYOJIKJ() {
        return (String) get(RepaVbjaMea10Irsk.IRSKALASHYOJIKJ);
    }

    /**
     * IRSKALASHYOJIKJを設定する
     *
     * @param val IRSKALASHYOJIKJ
     */
    public void setIRSKALASHYOJIKJ(String val) {
        set(RepaVbjaMea10Irsk.IRSKALASHYOJIKJ, val);
    }

    /**
     * TKALASHYOJIKNを取得する
     *
     * @return TKALASHYOJIKN
     */
    public String getTKALASHYOJIKN() {
        return (String) get(RepaVbjaMea10Irsk.TKALASHYOJIKN);
    }

    /**
     * TKALASHYOJIKNを設定する
     *
     * @param val TKALASHYOJIKN
     */
    public void setTKALASHYOJIKN(String val) {
        set(RepaVbjaMea10Irsk.TKALASHYOJIKN, val);
    }

    /**
     * TKALASHYOJIKJを取得する
     *
     * @return TKALASHYOJIKJ
     */
    public String getTKALASHYOJIKJ() {
        return (String) get(RepaVbjaMea10Irsk.TKALASHYOJIKJ);
    }

    /**
     * TKALASHYOJIKJを設定する
     *
     * @param val TKALASHYOJIKJ
     */
    public void setTKALASHYOJIKJ(String val) {
        set(RepaVbjaMea10Irsk.TKALASHYOJIKJ, val);
    }

    /**
     * ATSHONBCDを取得する
     *
     * @return ATSHONBCD
     */
    public String getATSHONBCD() {
        return (String) get(RepaVbjaMea10Irsk.ATSHONBCD);
    }

    /**
     * ATSHONBCDを設定する
     *
     * @param val ATSHONBCD
     */
    public void setATSHONBCD(String val) {
        set(RepaVbjaMea10Irsk.ATSHONBCD, val);
    }

    /**
     * ALASUSEFLGを取得する
     *
     * @return ALASUSEFLG
     */
    public String getALASUSEFLG() {
        return (String) get(RepaVbjaMea10Irsk.ALASUSEFLG);
    }

    /**
     * ALASUSEFLGを設定する
     *
     * @param val ALASUSEFLG
     */
    public void setALASUSEFLG(String val) {
        set(RepaVbjaMea10Irsk.ALASUSEFLG, val);
    }

    /**
     * TKALASUSEFLGを取得する
     *
     * @return TKALASUSEFLG
     */
    public String getTKALASUSEFLG() {
        return (String) get(RepaVbjaMea10Irsk.TKALASUSEFLG);
    }

    /**
     * TKALASUSEFLGを設定する
     *
     * @param val TKALASUSEFLG
     */
    public void setTKALASUSEFLG(String val) {
        set(RepaVbjaMea10Irsk.TKALASUSEFLG, val);
    }

    /**
     * HOSOKを取得する
     *
     * @return HOSOK
     */
    public String getHOSOK() {
        return (String) get(RepaVbjaMea10Irsk.HOSOK);
    }

    /**
     * HOSOKを設定する
     *
     * @param val HOSOK
     */
    public void setHOSOK(String val) {
        set(RepaVbjaMea10Irsk.HOSOK, val);
    }

    /**
     * HKYMDを取得する
     *
     * @return HKYMD
     */
    public String getHKYMD() {
        return (String) get(RepaVbjaMea10Irsk.HKYMD);
    }

    /**
     * HKYMDを設定する
     *
     * @param val HKYMD
     */
    public void setHKYMD(String val) {
        set(RepaVbjaMea10Irsk.HKYMD, val);
    }

    /**
     * HAISYMDを取得する
     *
     * @return HAISYMD
     */
    public String getHAISYMD() {
        return (String) get(RepaVbjaMea10Irsk.HAISYMD);
    }

    /**
     * HAISYMDを設定する
     *
     * @param val HAISYMD
     */
    public void setHAISYMD(String val) {
        set(RepaVbjaMea10Irsk.HAISYMD, val);
    }

    /**
     * INSDATEを取得する
     *
     * @return INSDATE
     */
    @XmlElement(required = true, nillable = true)
    public Date getINSDATE() {
        return (Date) get(RepaVbjaMea10Irsk.INSDATE);
    }

    /**
     * INSDATEを設定する
     *
     * @param val INSDATE
     */
    public void setINSDATE(Date val) {
        set(RepaVbjaMea10Irsk.INSDATE, val);
    }

    /**
     * INSTNTCDを取得する
     *
     * @return INSTNTCD
     */
    public String getINSTNTCD() {
        return (String) get(RepaVbjaMea10Irsk.INSTNTCD);
    }

    /**
     * INSTNTCDを設定する
     *
     * @param val INSTNTCD
     */
    public void setINSTNTCD(String val) {
        set(RepaVbjaMea10Irsk.INSTNTCD, val);
    }

    /**
     * INSAPLIDを取得する
     *
     * @return INSAPLID
     */
    public String getINSAPLID() {
        return (String) get(RepaVbjaMea10Irsk.INSAPLID);
    }

    /**
     * INSAPLIDを設定する
     *
     * @param val INSAPLID
     */
    public void setINSAPLID(String val) {
        set(RepaVbjaMea10Irsk.INSAPLID, val);
    }

    /**
     * UPDAPLDATEを取得する
     *
     * @return UPDAPLDATE
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDAPLDATE() {
        return (Date) get(RepaVbjaMea10Irsk.UPDAPLDATE);
    }

    /**
     * UPDAPLDATEを設定する
     *
     * @param val UPDAPLDATE
     */
    public void setUPDAPLDATE(Date val) {
        set(RepaVbjaMea10Irsk.UPDAPLDATE, val);
    }

    /**
     * UPDTNTCDを取得する
     *
     * @return UPDTNTCD
     */
    public String getUPDTNTCD() {
        return (String) get(RepaVbjaMea10Irsk.UPDTNTCD);
    }

    /**
     * UPDTNTCDを設定する
     *
     * @param val UPDTNTCD
     */
    public void setUPDTNTCD(String val) {
        set(RepaVbjaMea10Irsk.UPDTNTCD, val);
    }

    /**
     * UPDONLAPLIDを取得する
     *
     * @return UPDONLAPLID
     */
    public String getUPDONLAPLID() {
        return (String) get(RepaVbjaMea10Irsk.UPDONLAPLID);
    }

    /**
     * UPDONLAPLIDを設定する
     *
     * @param val UPDONLAPLID
     */
    public void setUPDONLAPLID(String val) {
        set(RepaVbjaMea10Irsk.UPDONLAPLID, val);
    }

    /**
     * UPDBATAPLIDを取得する
     *
     * @return UPDBATAPLID
     */
    public String getUPDBATAPLID() {
        return (String) get(RepaVbjaMea10Irsk.UPDBATAPLID);
    }

    /**
     * UPDBATAPLIDを設定する
     *
     * @param val UPDBATAPLID
     */
    public void setUPDBATAPLID(String val) {
        set(RepaVbjaMea10Irsk.UPDBATAPLID, val);
    }

}

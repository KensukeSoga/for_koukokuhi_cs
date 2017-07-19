package jp.co.isid.ham.common.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMea11DisplayIrsk;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 画面－発注先マスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMea11DisplayIrskVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMea11DisplayIrskVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new RepaVbjaMea11DisplayIrskVO();
    }

    /**
     * ATSEGSYOCDを取得する
     *
     * @return ATSEGSYOCD
     */
    public String getATSEGSYOCD() {
        return (String) get(RepaVbjaMea11DisplayIrsk.ATSEGSYOCD);
    }

    /**
     * ATSEGSYOCDを設定する
     *
     * @param val ATSEGSYOCD
     */
    public void setATSEGSYOCD(String val) {
        set(RepaVbjaMea11DisplayIrsk.ATSEGSYOCD, val);
    }

    /**
     * JYUCTYPEを取得する
     *
     * @return JYUCTYPE
     */
    public String getJYUCTYPE() {
        return (String) get(RepaVbjaMea11DisplayIrsk.JYUCTYPE);
    }

    /**
     * JYUCTYPEを設定する
     *
     * @param val JYUCTYPE
     */
    public void setJYUCTYPE(String val) {
        set(RepaVbjaMea11DisplayIrsk.JYUCTYPE, val);
    }

    /**
     * IRSKCDを取得する
     *
     * @return IRSKCD
     */
    public String getIRSKCD() {
        return (String) get(RepaVbjaMea11DisplayIrsk.IRSKCD);
    }

    /**
     * IRSKCDを設定する
     *
     * @param val IRSKCD
     */
    public void setIRSKCD(String val) {
        set(RepaVbjaMea11DisplayIrsk.IRSKCD, val);
    }

    /**
     * IRSKSUBCDを取得する
     *
     * @return IRSKSUBCD
     */
    public String getIRSKSUBCD() {
        return (String) get(RepaVbjaMea11DisplayIrsk.IRSKSUBCD);
    }

    /**
     * IRSKSUBCDを設定する
     *
     * @param val IRSKSUBCD
     */
    public void setIRSKSUBCD(String val) {
        set(RepaVbjaMea11DisplayIrsk.IRSKSUBCD, val);
    }

    /**
     * IRIKYKSHOWNOを取得する
     *
     * @return IRIKYKSHOWNO
     */
    public String getIRIKYKSHOWNO() {
        return (String) get(RepaVbjaMea11DisplayIrsk.IRIKYKSHOWNO);
    }

    /**
     * IRIKYKSHOWNOを設定する
     *
     * @param val IRIKYKSHOWNO
     */
    public void setIRIKYKSHOWNO(String val) {
        set(RepaVbjaMea11DisplayIrsk.IRIKYKSHOWNO, val);
    }

    /**
     * IRSKSHOWNOを取得する
     *
     * @return IRSKSHOWNO
     */
    public String getIRSKSHOWNO() {
        return (String) get(RepaVbjaMea11DisplayIrsk.IRSKSHOWNO);
    }

    /**
     * IRSKSHOWNOを設定する
     *
     * @param val IRSKSHOWNO
     */
    public void setIRSKSHOWNO(String val) {
        set(RepaVbjaMea11DisplayIrsk.IRSKSHOWNO, val);
    }

    /**
     * KISEKBNを取得する
     *
     * @return KISEKBN
     */
    public String getKISEKBN() {
        return (String) get(RepaVbjaMea11DisplayIrsk.KISEKBN);
    }

    /**
     * KISEKBNを設定する
     *
     * @param val KISEKBN
     */
    public void setKISEKBN(String val) {
        set(RepaVbjaMea11DisplayIrsk.KISEKBN, val);
    }

    /**
     * DSIKKBNCDを取得する
     *
     * @return DSIKKBNCD
     */
    public String getDSIKKBNCD() {
        return (String) get(RepaVbjaMea11DisplayIrsk.DSIKKBNCD);
    }

    /**
     * DSIKKBNCDを設定する
     *
     * @param val DSIKKBNCD
     */
    public void setDSIKKBNCD(String val) {
        set(RepaVbjaMea11DisplayIrsk.DSIKKBNCD, val);
    }

    /**
     * JYUCFLGを取得する
     *
     * @return JYUCFLG
     */
    public String getJYUCFLG() {
        return (String) get(RepaVbjaMea11DisplayIrsk.JYUCFLG);
    }

    /**
     * JYUCFLGを設定する
     *
     * @param val JYUCFLG
     */
    public void setJYUCFLG(String val) {
        set(RepaVbjaMea11DisplayIrsk.JYUCFLG, val);
    }

    /**
     * TKFLGを取得する
     *
     * @return TKFLG
     */
    public String getTKFLG() {
        return (String) get(RepaVbjaMea11DisplayIrsk.TKFLG);
    }

    /**
     * TKFLGを設定する
     *
     * @param val TKFLG
     */
    public void setTKFLG(String val) {
        set(RepaVbjaMea11DisplayIrsk.TKFLG, val);
    }

    /**
     * HKYMDを取得する
     *
     * @return HKYMD
     */
    public String getHKYMD() {
        return (String) get(RepaVbjaMea11DisplayIrsk.HKYMD);
    }

    /**
     * HKYMDを設定する
     *
     * @param val HKYMD
     */
    public void setHKYMD(String val) {
        set(RepaVbjaMea11DisplayIrsk.HKYMD, val);
    }

    /**
     * HAISYMDを取得する
     *
     * @return HAISYMD
     */
    public String getHAISYMD() {
        return (String) get(RepaVbjaMea11DisplayIrsk.HAISYMD);
    }

    /**
     * HAISYMDを設定する
     *
     * @param val HAISYMD
     */
    public void setHAISYMD(String val) {
        set(RepaVbjaMea11DisplayIrsk.HAISYMD, val);
    }

    /**
     * INSDATEを取得する
     *
     * @return INSDATE
     */
    @XmlElement(required = true, nillable = true)
    public Date getINSDATE() {
        return (Date) get(RepaVbjaMea11DisplayIrsk.INSDATE);
    }

    /**
     * INSDATEを設定する
     *
     * @param val INSDATE
     */
    public void setINSDATE(Date val) {
        set(RepaVbjaMea11DisplayIrsk.INSDATE, val);
    }

    /**
     * INSTNTCDを取得する
     *
     * @return INSTNTCD
     */
    public String getINSTNTCD() {
        return (String) get(RepaVbjaMea11DisplayIrsk.INSTNTCD);
    }

    /**
     * INSTNTCDを設定する
     *
     * @param val INSTNTCD
     */
    public void setINSTNTCD(String val) {
        set(RepaVbjaMea11DisplayIrsk.INSTNTCD, val);
    }

    /**
     * INSAPLIDを取得する
     *
     * @return INSAPLID
     */
    public String getINSAPLID() {
        return (String) get(RepaVbjaMea11DisplayIrsk.INSAPLID);
    }

    /**
     * INSAPLIDを設定する
     *
     * @param val INSAPLID
     */
    public void setINSAPLID(String val) {
        set(RepaVbjaMea11DisplayIrsk.INSAPLID, val);
    }

    /**
     * UPDAPLDATEを取得する
     *
     * @return UPDAPLDATE
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDAPLDATE() {
        return (Date) get(RepaVbjaMea11DisplayIrsk.UPDAPLDATE);
    }

    /**
     * UPDAPLDATEを設定する
     *
     * @param val UPDAPLDATE
     */
    public void setUPDAPLDATE(Date val) {
        set(RepaVbjaMea11DisplayIrsk.UPDAPLDATE, val);
    }

    /**
     * UPDTNTCDを取得する
     *
     * @return UPDTNTCD
     */
    public String getUPDTNTCD() {
        return (String) get(RepaVbjaMea11DisplayIrsk.UPDTNTCD);
    }

    /**
     * UPDTNTCDを設定する
     *
     * @param val UPDTNTCD
     */
    public void setUPDTNTCD(String val) {
        set(RepaVbjaMea11DisplayIrsk.UPDTNTCD, val);
    }

    /**
     * UPDONLAPLIDを取得する
     *
     * @return UPDONLAPLID
     */
    public String getUPDONLAPLID() {
        return (String) get(RepaVbjaMea11DisplayIrsk.UPDONLAPLID);
    }

    /**
     * UPDONLAPLIDを設定する
     *
     * @param val UPDONLAPLID
     */
    public void setUPDONLAPLID(String val) {
        set(RepaVbjaMea11DisplayIrsk.UPDONLAPLID, val);
    }

    /**
     * UPDBATAPLIDを取得する
     *
     * @return UPDBATAPLID
     */
    public String getUPDBATAPLID() {
        return (String) get(RepaVbjaMea11DisplayIrsk.UPDBATAPLID);
    }

    /**
     * UPDBATAPLIDを設定する
     *
     * @param val UPDBATAPLID
     */
    public void setUPDBATAPLID(String val) {
        set(RepaVbjaMea11DisplayIrsk.UPDBATAPLID, val);
    }

}

package jp.co.isid.ham.common.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMea12DisplayGyomKbn;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 画面－業務区分VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMea12DisplayGyomKbnVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMea12DisplayGyomKbnVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new RepaVbjaMea12DisplayGyomKbnVO();
    }

    /**
     * JYUCTYPEを取得する
     *
     * @return JYUCTYPE
     */
    public String getJYUCTYPE() {
        return (String) get(RepaVbjaMea12DisplayGyomKbn.JYUCTYPE);
    }

    /**
     * JYUCTYPEを設定する
     *
     * @param val JYUCTYPE
     */
    public void setJYUCTYPE(String val) {
        set(RepaVbjaMea12DisplayGyomKbn.JYUCTYPE, val);
    }

    /**
     * IRSKCDを取得する
     *
     * @return IRSKCD
     */
    public String getIRSKCD() {
        return (String) get(RepaVbjaMea12DisplayGyomKbn.IRSKCD);
    }

    /**
     * IRSKCDを設定する
     *
     * @param val IRSKCD
     */
    public void setIRSKCD(String val) {
        set(RepaVbjaMea12DisplayGyomKbn.IRSKCD, val);
    }

    /**
     * IRSKSUBCDを取得する
     *
     * @return IRSKSUBCD
     */
    public String getIRSKSUBCD() {
        return (String) get(RepaVbjaMea12DisplayGyomKbn.IRSKSUBCD);
    }

    /**
     * IRSKSUBCDを設定する
     *
     * @param val IRSKSUBCD
     */
    public void setIRSKSUBCD(String val) {
        set(RepaVbjaMea12DisplayGyomKbn.IRSKSUBCD, val);
    }

    /**
     * GYOMKBNCDを取得する
     *
     * @return GYOMKBNCD
     */
    public String getGYOMKBNCD() {
        return (String) get(RepaVbjaMea12DisplayGyomKbn.GYOMKBNCD);
    }

    /**
     * GYOMKBNCDを設定する
     *
     * @param val GYOMKBNCD
     */
    public void setGYOMKBNCD(String val) {
        set(RepaVbjaMea12DisplayGyomKbn.GYOMKBNCD, val);
    }

    /**
     * GYOMKBNSHOWNOを取得する
     *
     * @return GYOMKBNSHOWNO
     */
    public String getGYOMKBNSHOWNO() {
        return (String) get(RepaVbjaMea12DisplayGyomKbn.GYOMKBNSHOWNO);
    }

    /**
     * GYOMKBNSHOWNOを設定する
     *
     * @param val GYOMKBNSHOWNO
     */
    public void setGYOMKBNSHOWNO(String val) {
        set(RepaVbjaMea12DisplayGyomKbn.GYOMKBNSHOWNO, val);
    }

    /**
     * KISEKBNを取得する
     *
     * @return KISEKBN
     */
    public String getKISEKBN() {
        return (String) get(RepaVbjaMea12DisplayGyomKbn.KISEKBN);
    }

    /**
     * KISEKBNを設定する
     *
     * @param val KISEKBN
     */
    public void setKISEKBN(String val) {
        set(RepaVbjaMea12DisplayGyomKbn.KISEKBN, val);
    }

    /**
     * HKYMDを取得する
     *
     * @return HKYMD
     */
    public String getHKYMD() {
        return (String) get(RepaVbjaMea12DisplayGyomKbn.HKYMD);
    }

    /**
     * HKYMDを設定する
     *
     * @param val HKYMD
     */
    public void setHKYMD(String val) {
        set(RepaVbjaMea12DisplayGyomKbn.HKYMD, val);
    }

    /**
     * HAISYMDを取得する
     *
     * @return HAISYMD
     */
    public String getHAISYMD() {
        return (String) get(RepaVbjaMea12DisplayGyomKbn.HAISYMD);
    }

    /**
     * HAISYMDを設定する
     *
     * @param val HAISYMD
     */
    public void setHAISYMD(String val) {
        set(RepaVbjaMea12DisplayGyomKbn.HAISYMD, val);
    }

    /**
     * INSDATEを取得する
     *
     * @return INSDATE
     */
    @XmlElement(required = true, nillable = true)
    public Date getINSDATE() {
        return (Date) get(RepaVbjaMea12DisplayGyomKbn.INSDATE);
    }

    /**
     * INSDATEを設定する
     *
     * @param val INSDATE
     */
    public void setINSDATE(Date val) {
        set(RepaVbjaMea12DisplayGyomKbn.INSDATE, val);
    }

    /**
     * INSTNTCDを取得する
     *
     * @return INSTNTCD
     */
    public String getINSTNTCD() {
        return (String) get(RepaVbjaMea12DisplayGyomKbn.INSTNTCD);
    }

    /**
     * INSTNTCDを設定する
     *
     * @param val INSTNTCD
     */
    public void setINSTNTCD(String val) {
        set(RepaVbjaMea12DisplayGyomKbn.INSTNTCD, val);
    }

    /**
     * INSAPLIDを取得する
     *
     * @return INSAPLID
     */
    public String getINSAPLID() {
        return (String) get(RepaVbjaMea12DisplayGyomKbn.INSAPLID);
    }

    /**
     * INSAPLIDを設定する
     *
     * @param val INSAPLID
     */
    public void setINSAPLID(String val) {
        set(RepaVbjaMea12DisplayGyomKbn.INSAPLID, val);
    }

    /**
     * UPDAPLDATEを取得する
     *
     * @return UPDAPLDATE
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDAPLDATE() {
        return (Date) get(RepaVbjaMea12DisplayGyomKbn.UPDAPLDATE);
    }

    /**
     * UPDAPLDATEを設定する
     *
     * @param val UPDAPLDATE
     */
    public void setUPDAPLDATE(Date val) {
        set(RepaVbjaMea12DisplayGyomKbn.UPDAPLDATE, val);
    }

    /**
     * UPDTNTCDを取得する
     *
     * @return UPDTNTCD
     */
    public String getUPDTNTCD() {
        return (String) get(RepaVbjaMea12DisplayGyomKbn.UPDTNTCD);
    }

    /**
     * UPDTNTCDを設定する
     *
     * @param val UPDTNTCD
     */
    public void setUPDTNTCD(String val) {
        set(RepaVbjaMea12DisplayGyomKbn.UPDTNTCD, val);
    }

    /**
     * UPDONLAPLIDを取得する
     *
     * @return UPDONLAPLID
     */
    public String getUPDONLAPLID() {
        return (String) get(RepaVbjaMea12DisplayGyomKbn.UPDONLAPLID);
    }

    /**
     * UPDONLAPLIDを設定する
     *
     * @param val UPDONLAPLID
     */
    public void setUPDONLAPLID(String val) {
        set(RepaVbjaMea12DisplayGyomKbn.UPDONLAPLID, val);
    }

    /**
     * UPDBATAPLIDを取得する
     *
     * @return UPDBATAPLID
     */
    public String getUPDBATAPLID() {
        return (String) get(RepaVbjaMea12DisplayGyomKbn.UPDBATAPLID);
    }

    /**
     * UPDBATAPLIDを設定する
     *
     * @param val UPDBATAPLID
     */
    public void setUPDBATAPLID(String val) {
        set(RepaVbjaMea12DisplayGyomKbn.UPDBATAPLID, val);
    }

}

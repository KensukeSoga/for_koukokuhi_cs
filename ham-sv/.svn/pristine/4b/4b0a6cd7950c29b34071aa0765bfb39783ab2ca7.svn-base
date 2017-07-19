package jp.co.isid.ham.media.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMea10Irsk;
import jp.co.isid.ham.integ.tbl.RepaVbjaMea11DisplayIrsk;
import jp.co.isid.ham.integ.tbl.RepaVbjaMea12DisplayGyomKbn;
import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 組織VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/02/19 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindSocietyDataVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindSocietyDataVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindSocietyDataVO();
    }

    /**
     * 台帳Noを取得する
     *
     * @return 台帳No
     */
    public String getDAICHONO() {
        return (String) get(Tbj02EigyoDaicho.DAICHONO);
    }

    /**
     * 台帳Noを設定する
     *
     * @param val 台帳No
     */
    public void setDAICHONO(String val) {
        set(Tbj02EigyoDaicho.DAICHONO, val);
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
}

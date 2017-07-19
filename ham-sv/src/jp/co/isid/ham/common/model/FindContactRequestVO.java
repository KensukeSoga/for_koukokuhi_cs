package jp.co.isid.ham.common.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 依頼先VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/08/02 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class FindContactRequestVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindContactRequestVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new FindContactRequestVO();
    }

    /**
     * 依頼先コード取得
     *
     * @return 依頼先コード
     */
    public String getIRAISAKICODE() {
        return (String) get("IRAISAKICODE");
    }

    /**
     * 依頼先コード設定
     *
     * @param val 依頼先コード
     */
    public void setIRAISAKICODE(String val) {
        set("IRAISAKICODE", val);
    }

    /**
     * 依頼先名取得
     *
     * @return 依頼先名
     */
    public String getIRAISAKINAME() {
        return (String) get("IRAISAKINAME");
    }

    /**
     * 依頼先名設定
     *
     * @param val 依頼先名
     */
    public void setIRAISAKINAME(String val) {
        set("IRAISAKINAME", val);
    }

    public String getDSIKKBNCD() {
        return (String) get("DSIKKBNCD");
    }

    public void setDSIKKBNCD(String val) {
        set("IRAISAKINAME", val);
    }

    public String getIRSKSHOWNO() {
        return (String) get("IRSKSHOWNO");
    }

    public void setIRSKSHOWNO(String val) {
        set("IRSKSHOWNO", val);
    }
}

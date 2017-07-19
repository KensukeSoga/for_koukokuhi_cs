package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.common.model.Tbj16ContractInfoVO;
import jp.co.isid.ham.integ.tbl.Mbj05Car;

/**
 * <P>
 * 契約情報VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/04 HAMチーム)<BR>
 * </P>
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class ContractSearchVO extends Tbj16ContractInfoVO {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /**
     * 契約区分名称
     */
    private String _CTRTKBNNAME = null;

    /**
     * CD販売（名称）
     */
    private String _SALES = null;

    /**
     * JASRAC登録（名称）
     */
    private String _JASRAC = null;

    /**
     * デフォルトコンストラクタ
     */
    public ContractSearchVO() {
        //スーパークラスのコンストラクタを呼び出す
        super();
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new ContractSearchVO();
    }

    /**
     * 車種名を取得します
     * @param val
     */
    public void setCARNM(String val) {
        super.set(Mbj05Car.CARNM, val);
    }

    /**
     * 車種名を設定します
     * @return
     */
    public String getCARNM() {
        return (String)super.get(Mbj05Car.CARNM);
    }

    /**
     * 契約区分名称を取得します
     * @return
     */
    public String getCTRTKBNNAME() {
        return _CTRTKBNNAME;
    }

    /**
     * 契約区分名称を設定します
     * @param val
     */
    public void setCTRTKBNNAME(String val) {
        _CTRTKBNNAME = val;
    }

    /**
     * CD販売（名称）
     * @return
     */
    public String getSALES() {
        return _SALES;
    }

    /**
     * CD販売（名称）
     * @param val
     */
    public void setSALES(String val) {
        _SALES = val;
    }

    /**
     * JASRAC登録（名称）
     * @return
     */
    public String getJASRAC() {
        return _JASRAC;
    }

    /**
     * JASRAC登録（名称）
     * @param val
     */
    public void setJASRAC(String val) {
        _JASRAC = val;
    }
}

package jp.co.isid.ham.production.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.common.model.Tbj16ContractInfoVO;
import jp.co.isid.ham.integ.tbl.Tbj17Content;

/**
 * <P>
 * 素材一覧画面契約情報VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/04 HAMチーム)<BR>
 * </P>
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class MaterialListCntrctVO extends Tbj16ContractInfoVO {

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
    public MaterialListCntrctVO() {
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
        return new MaterialListCntrctVO();
    }

    /**
     * 10桁CMｺｰﾄﾞを取得する
     *
     * @return 10桁CMｺｰﾄﾞ
     */
    public String getCMCD() {
        return (String) get(Tbj17Content.CMCD);
    }

    /**
     * 10桁CMｺｰﾄﾞを設定する
     *
     * @param val 10桁CMｺｰﾄﾞ
     */
    public void setCMCD(String val) {
        set(Tbj17Content.CMCD, val);
    }

    /**
     * 契約区分名称を設定します
     * @param val
     */
    public void setCTRTKBNNAME(String val) {
        _CTRTKBNNAME = val;
    }

    /**
     * 契約区分名称を取得します
     * @return
     */
    public String getCTRTKBNNAME() {
        return _CTRTKBNNAME;
    }

    /**
     * CD販売（名称）
     * @param val
     */
    public void setSALES(String val) {
        _SALES = val;
    }

    /**
     * CD販売（名称）
     * @return
     */
    public String getSALES() {
        return _SALES;
    }

    /**
     * JASRAC登録（名称）
     * @param val
     */
    public void setJASRAC(String val) {
        _JASRAC = val;
    }

    /**
     * JASRAC登録（名称）
     * @return
     */
    public String getJASRAC() {
        return _JASRAC;
    }

    /**
     * データ作成日時を取得する
     *
     * @return データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCONCRTDATE() {
        return (Date) get(Tbj17Content.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     *
     * @param val データ作成日時
     */
    public void setCONCRTDATE(Date val) {
        set(Tbj17Content.CRTDATE, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCONUPDDATE() {
        return (Date) get(Tbj17Content.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setCONUPDDATE(Date val) {
        set(Tbj17Content.UPDDATE, val);
    }

}

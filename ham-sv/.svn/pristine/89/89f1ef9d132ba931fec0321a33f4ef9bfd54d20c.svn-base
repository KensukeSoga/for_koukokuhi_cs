package jp.co.isid.ham.menu.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj29LoginUser;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ログインVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.menu.ham.isid.co.jp/")
@XmlType(namespace = "http://model.menu.ham.isid.co.jp/")
public class LoginVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public LoginVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new LoginVO();
    }

    /**
     * 更新日時を取得する
     *
     * @return 更新日時
     */
    @XmlElement(required = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj29LoginUser.UPDDATE);
    }

    /**
     * 更新日時を設定する
     *
     * @param val 更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj29LoginUser.UPDDATE, val);
    }

    /**
     * 部署名を取得する
     *
     * @return 部署名
     */
    public String getAFFILIATION() {
        return (String) get(Tbj29LoginUser.AFFILIATION);
    }

    /**
     * 部署名を設定する
     *
     * @param val 部署名
     */
    public void setAFFILIATION(String val) {
        set(Tbj29LoginUser.AFFILIATION, val);
    }

    /**
     * HAMIDを取得する
     *
     * @return HAMID
     */
    public String getHAMID() {
        return (String) get(Tbj29LoginUser.HAMID);
    }

    /**
     * HAMIDを設定する
     *
     * @param val HAMID
     */
    public void setHAMID(String val) {
        set(Tbj29LoginUser.HAMID, val);
    }

    /**
     * 氏名を取得する
     *
     * @return 氏名
     */
    public String getFULLNAME() {
        return (String) get("FULLNAME");
    }

    /**
     * 氏名を設定する
     *
     * @param val 氏名
     */
    public void setFULLNAME(String val) {
        set("FULLNAME", val);
    }
}

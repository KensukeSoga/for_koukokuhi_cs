package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj02User;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj52SzTntUser;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 車種担当者VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/02/29 HDX対応 HLC K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class SzTntUserListVO extends AbstractModel {

    private static final long serialVersionUID = 1L;

    /**
     * コンストラクタ
     */
    public SzTntUserListVO() {

    }
    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new SzTntUserListVO();
    }

    /**
     * 担当者姓を取得する
     * @return
     */
    public String getUSERNAME1() {
        return (String) get(Mbj02User.USERNAME1);
    }

    /**
     * 担当者姓を設定する
     * @param val
     */
    public void setUSERNAME1(String val) {
        set(Mbj02User.USERNAME1, val);
    }

    /**
     * 担当者名を取得する
     * @return
     */
    public String getUSERNAME2() {
        return (String) get(Mbj02User.USERNAME2);
    }

    /**
     * 担当者名を設定する
     * @param val
     */
    public void setUSERNAME2(String val) {
        set(Mbj02User.USERNAME2, val);
    }

    /**
     * 電通車種名を取得する
     * @return
     */
    public String getCARNM() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * 電通車種名を設定する
     * @param val
     */
    public void setCARNM(String val) {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * 電通車種コードを取得する
     * @return
     */
    public String getDCARCD() {
        return (String) get(Mbj52SzTntUser.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     * @param val
     */
    public void setDCARCD(String val) {
        set(Mbj52SzTntUser.DCARCD, val);
    }
}

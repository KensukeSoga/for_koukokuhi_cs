package jp.co.isid.ham.common.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj02User;

/**
 * <P>
 * 担当者マスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/07/05 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj41AlertDispControlWithUserVO extends Mbj41AlertDispControlVO {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj41AlertDispControlWithUserVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Mbj41AlertDispControlWithUserVO();
    }

    /**
     * 担当者姓を取得する
     *
     * @return 担当者姓
     */
    public String getUSERNAME1() {
        return (String) get(Mbj02User.USERNAME1);
    }

    /**
     * 担当者姓を設定する
     *
     * @param val 担当者姓
     */
    public void setUSERNAME1(String val) {
        set(Mbj02User.USERNAME1, val);
    }

    /**
     * 担当者名を取得する
     *
     * @return 担当者名
     */
    public String getUSERNAME2() {
        return (String) get(Mbj02User.USERNAME2);
    }

    /**
     * 担当者名を設定する
     *
     * @param val 担当者名
     */
    public void setUSERNAME2(String val) {
        set(Mbj02User.USERNAME2, val);
    }

}

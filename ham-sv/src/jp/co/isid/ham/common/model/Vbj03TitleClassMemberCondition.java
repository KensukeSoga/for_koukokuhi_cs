package jp.co.isid.ham.common.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 新HAM向けVIEW(職位等級グループメンバー情報)検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Vbj03TitleClassMemberCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** グループコード */
    private String _groupcd = null;

    /** ESQID */
    private String _esqid = null;

    /**
     * デフォルトコンストラクタ
     */
    public Vbj03TitleClassMemberCondition() {
    }

    /**
     * グループコードを取得する
     *
     * @return グループコード
     */
    public String getGroupcd() {
        return _groupcd;
    }

    /**
     * グループコードを設定する
     *
     * @param groupcd グループコード
     */
    public void setGroupcd(String groupcd) {
        this._groupcd = groupcd;
    }

    /**
     * ESQIDを取得する
     *
     * @return ESQID
     */
    public String getEsqid() {
        return _esqid;
    }

    /**
     * ESQIDを設定する
     *
     * @param esqid ESQID
     */
    public void setEsqid(String esqid) {
        this._esqid = esqid;
    }

}

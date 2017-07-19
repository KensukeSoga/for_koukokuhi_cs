package jp.co.isid.ham.common.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Vbj03TitleClassMember;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 新HAM向けVIEW(職位等級グループメンバー情報)VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Vbj03TitleClassMemberVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Vbj03TitleClassMemberVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Vbj03TitleClassMemberVO();
    }

    /**
     * グループコードを取得する
     *
     * @return グループコード
     */
    public String getGROUPCD() {
        return (String) get(Vbj03TitleClassMember.GROUPCD);
    }

    /**
     * グループコードを設定する
     *
     * @param val グループコード
     */
    public void setGROUPCD(String val) {
        set(Vbj03TitleClassMember.GROUPCD, val);
    }

    /**
     * ESQIDを取得する
     *
     * @return ESQID
     */
    public String getESQID() {
        return (String) get(Vbj03TitleClassMember.ESQID);
    }

    /**
     * ESQIDを設定する
     *
     * @param val ESQID
     */
    public void setESQID(String val) {
        set(Vbj03TitleClassMember.ESQID, val);
    }

}

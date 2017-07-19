package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * BudgetDetailsDAO.findBudgetDetailsで取得したデータを格納するVOクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/07 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */

@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindCheckListHattyuKykVO extends AbstractModel {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindCheckListHattyuKykVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindCheckListHattyuKykVO();
    }

    /**
     * 局コードを取得する
     *
     * @return 局コード
     */
    public String getSIKCDKYK() {
        return (String) get("SIKCDKYK");
    }

    /**
     * 局コードを設定する
     *
     * @param val 局コード
     */
    public void setSIKCDKYK(String val) {
        set("SIKCDKYK", val);
    }

    /**
     * 局名を取得する
     *
     * @return 姓名
     */
    public String getKYOKUNM() {
        return (String) get("KYOKUNM");
    }

    /**
     * 局名を設定する
     *
     * @param val 姓名
     */
    public void setKYOKUNM(String val) {
        set("KYOKUNM", val);
    }

    /**
     * 依頼先組織コードを取得する
     *
     * @return 依頼先組織コード
     */
    public String getSIKCD() {
        return (String) get("SIKCD");
    }

    /**
     * 依頼先組織コードを設定する
     *
     * @param val 依頼先組織コード
     */
    public void setSIKCD(String val) {
        set("SIKCD", val);
    }
}

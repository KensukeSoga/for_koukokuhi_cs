package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.integ.tbl.Vbj01AccUser;
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
public class FindCheckListTantoVO extends AbstractModel {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindCheckListTantoVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindCheckListTantoVO();
    }

    /**
     * 担当者コードを取得する
     *
     * @return 担当者コード
     */
    public String getEGTNTCD() {
        return (String) get("EGTNTCD");
    }

    /**
     * 担当者コードを設定する
     *
     * @param val 担当者コード
     */
    public void setEGTNTCD(String val) {
        set("EGTNTCD", val);
    }

    /**
     * 姓名を取得する
     *
     * @return 姓名
     */
    public String getCN() {
        return (String) get(Vbj01AccUser.CN);
    }

    /**
     * 姓名を設定する
     *
     * @param val 姓名
     */
    public void setCN(String val) {
        set(Vbj01AccUser.CN, val);
    }

    /**
     * 依頼先組織コードを取得する
     *
     * @return 依頼先組織コード
     */
    public String getIRAISSIKCD() {
        return (String) get("IRAISSIKCD");
    }

    /**
     * 依頼先組織コードを設定する
     *
     * @param val 依頼先組織コード
     */
    public void setIRAISSIKCD(String val) {
        set("IRAISSIKCD", val);
    }
}

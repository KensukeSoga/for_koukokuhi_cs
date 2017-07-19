package jp.co.isid.ham.production.model;

import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.common.model.Tbj32CompurposeVO;
import jp.co.isid.ham.common.model.Tbj33CrBudgetUpdHisVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * CR制作費　検索実行時のデータ取得の結果クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/30 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindBudgetDetailsResult extends AbstractServiceResult {

    /* ============================================================================= */
    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
    private String _dummy;

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを取得します
     *
     * @return String ダミープロパティ
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを設定します
     *
     * @param dummy ダミープロパティ
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }

    /* ============================================================================= */

    /** Tbj32CompurposeVO */
    private Tbj32CompurposeVO _tbj32CompurposeVo = null;

    /** Tbj33CrBudgetUpdHisVO */
    private Tbj33CrBudgetUpdHisVO _tbj33CrBudgetUpdHisVo = null;

    /** FindBudgetVOリスト */
    private List<FindBudgetVO> _findBudgetVoList = null;

    /**
     * Tbj32CompurposeVOを取得する
     *
     * @return Tbj32CompurposeVO
     */
    public Tbj32CompurposeVO getTbj32CompurposeVO() {
        return _tbj32CompurposeVo;
    }

    /**
     * Tbj32CompurposeVOを設定する
     *
     * @param Tbj32CompurposeVO Tbj32CompurposeVO
     */
    public void setTbj32CompurposeVO(Tbj32CompurposeVO tbj32CompurposeVo) {
        this._tbj32CompurposeVo = tbj32CompurposeVo;
    }

    /**
     * Tbj33CrBudgetUpdHisVOを取得する
     *
     * @return Tbj33CrBudgetUpdHisVO
     */
    public Tbj33CrBudgetUpdHisVO getTbj33CrBudgetUpdHisVO() {
        return _tbj33CrBudgetUpdHisVo;
    }

    /**
     * Tbj33CrBudgetUpdHisVOを設定する
     *
     * @param Tbj33CrBudgetUpdHisVO Tbj33CrBudgetUpdHisVO
     */
    public void setTbj33CrBudgetUpdHisVO(Tbj33CrBudgetUpdHisVO tbj33CrBudgetUpdHisVo) {
        this._tbj33CrBudgetUpdHisVo = tbj33CrBudgetUpdHisVo;
    }

    /**
     * FindBudgetVOリストを取得する
     *
     * @return FindBudgetVOリスト
     */
    public List<FindBudgetVO> getFindBudgetVoList() {
        return _findBudgetVoList;
    }

    /**
     * FindBudgetVOリストを設定する
     *
     * @param findBudgetVoList FindBudgetVOリスト
     */
    public void setFindBudgetVoList(List<FindBudgetVO> findBudgetVoList) {
        this._findBudgetVoList = findBudgetVoList;
    }

}

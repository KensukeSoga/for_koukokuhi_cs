package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.common.model.Tbj31CrBudgetPlanVO;
import jp.co.isid.ham.common.model.Tbj32CompurposeVO;

/**
 * <P>
 * CR制作費　登録実行時の登録データ保持クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/05 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class RegisterBudgetVO implements Serializable {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

    /** CR予算の最大タイムスタンプ */
    private Date _maxDateTime = null;

    /** 検索条件VO */
    private FindBudgetDetailsCondition _findBudgetDetailsCondition = null;

    /** CR予算VOリスト */
    private List<Tbj31CrBudgetPlanVO> _tbj31CrBudgetPlanVoList = null;

    /** 汎用コメントVOリスト */
    private Tbj32CompurposeVO _tbj32CompurposeVo = null;

    /**
     * CR予算のタイムスタンプ最大値を取得する
     *
     * @return CR予算のタイムスタンプ最大値
     */
    @XmlElement(required = true, nillable=true)
    public Date getMaxDateTime() {
        return _maxDateTime;
    }

    /**
     * CR予算のタイムスタンプ最大値を設定する
     *
     * @param maxDateTime CR予算のタイムスタンプ最大値
     */
    public void setMaxDateTime(Date maxDateTime) {
        this._maxDateTime = maxDateTime;
    }

    /**
     * 検索条件を取得する
     *
     * @return 検索条件VO
     */
    public FindBudgetDetailsCondition getFindBudgetDetailsCondition() {
        return _findBudgetDetailsCondition;
    }

    /**
     * 検索条件を設定する
     *
     * @param findBudgetDetailsCondition 検索条件VO
     */
    public void FindBudgetDetailsCondition(FindBudgetDetailsCondition findBudgetDetailsCondition) {
        this._findBudgetDetailsCondition = findBudgetDetailsCondition;
    }

    /**
     * CR予算VOリストを取得する
     *
     * @return CR予算VOリスト
     */
    public List<Tbj31CrBudgetPlanVO> getTbj31CrBudgetPlanVoList() {
        return _tbj31CrBudgetPlanVoList;
    }

    /**
     * CR予算リストを設定する
     *
     * @param tbj31CrBudgetPlanVoList CR予算VOリスト
     */
    public void setTbj31CrBudgetPlanVoList(List<Tbj31CrBudgetPlanVO> tbj31CrBudgetPlanVoList) {
        this._tbj31CrBudgetPlanVoList = tbj31CrBudgetPlanVoList;
    }

    /**
     * 汎用コメントVOを取得する
     *
     * @return 汎用コメントVO
     */
    public Tbj32CompurposeVO getTbj32CompurposeVo() {
        return _tbj32CompurposeVo;
    }

    /**
     * 汎用コメントを設定する
     *
     * @param tbj32CompurposeVo 汎用コメントVO
     */
    public void setTbj32CompurposeVo(Tbj32CompurposeVO tbj32CompurposeVo) {
        this._tbj32CompurposeVo = tbj32CompurposeVo;
    }

}

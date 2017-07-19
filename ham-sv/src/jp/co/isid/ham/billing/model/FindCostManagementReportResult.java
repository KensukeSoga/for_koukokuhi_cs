package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj26BillGroupVO;
import jp.co.isid.ham.common.model.OutputCarVO;
import jp.co.isid.ham.common.model.OutputMediaVO;
import jp.co.isid.ham.common.model.Tbj14FeeKanriVO;
import jp.co.isid.ham.common.model.Tbj34CutManagementVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * コスト管理表出力データ検索結果
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/2 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindCostManagementReportResult extends AbstractServiceResult {

    /**
     * 媒体(営業作業台帳)コスト
     */
    List<FindMediaCostVO> _mediaCost;

    /**
     * 制作費コスト
     */
    List<FindCreateCostVO> _createCost;

    /**
     * 制作費取込コスト
     */
    List<FindCreateUptakeCostVO> _uptakeCost;

    /**
     * コードマスタ
     */
    List<Mbj12CodeVO> _code;

    /**
     * フィー管理
     */
    List<Tbj14FeeKanriVO> _fee;

    /**
     * 出力車種
     */
    List<OutputCarVO> _car;

    /**
     * 出力媒体
     */
    List<OutputMediaVO> _media;

    /**
     * 請求先グループ
     */
    List<Mbj26BillGroupVO> _group;

    /**
     * 削減率管理
     */
    List<Tbj34CutManagementVO> _cut;

    /**
     * 媒体コストを取得
     * @return
     */
    public List<FindMediaCostVO> getFindMediaCostVO() {
        return _mediaCost;
    }

    /**
     * 媒体コストを設定
     * @param mediaCost
     */
    public void setFindMediaCostVO(List<FindMediaCostVO> mediaCost) {
        _mediaCost = mediaCost;
    }

    /**
     * 制作費コストを取得
     * @return
     */
    public List<FindCreateCostVO> getFindCreateCostVO() {
        return _createCost;
    }

    /**
     * 制作費コストを設定
     * @param createCost
     */
    public void setFindCreateCostVO(List<FindCreateCostVO> createCost) {
        _createCost = createCost;
    }

    /**
     * 制作費取込コストを取得
     * @return
     */
    public List<FindCreateUptakeCostVO> getFindCreateUptakeCostVO() {
        return _uptakeCost;
    }

    /**
     * 制作費取込コストを設定
     * @param uptakeCost
     */
    public void setFindCreateUptakeCostVO(List<FindCreateUptakeCostVO> uptakeCost) {
        _uptakeCost = uptakeCost;
    }

    /**
     * コードマスタを取得
     * @return
     */
    public List<Mbj12CodeVO> getMbj12CodeVO() {
        return _code;
    }

    /**
     * コードマスタを設定
     * @param code
     */
    public void setMbj12CodeVO(List<Mbj12CodeVO> code) {
        _code = code;
    }

    /**
     * フィー管理を取得
     * @return
     */
    public List<Tbj14FeeKanriVO> getTbj14FeeKanriVO() {
        return _fee;
    }

    /**
     * フィー管理を設定
     * @param fee
     */
    public void setTbj14FeeKanriVO(List<Tbj14FeeKanriVO> fee) {
        _fee = fee;
    }

    /**
     * 出力媒体を取得
     * @return
     */
    public List<OutputMediaVO> getOutputMediaVO() {
        return _media;
    }

    /**
     * 出力媒体を設定
     * @param media
     */
    public void setOutputMediaVO(List<OutputMediaVO> media) {
        _media = media;
    }

    /**
     * 出力車種を取得
     * @return
     */
    public List<OutputCarVO> getOutputCarVO() {
        return _car;
    }

    /**
     * 出力車種を設定
     * @param car
     */
    public void setOutputCarVO(List<OutputCarVO> car) {
        _car = car;
    }

    /**
     * 請求先グループを取得
     * @return
     */
    public List<Mbj26BillGroupVO> getMbj26BillGroupVO() {
        return _group;
    }

    /**
     * 請求先グループを設定
     * @param group
     */
    public void setMbj26BillGroupVO(List<Mbj26BillGroupVO> group) {
        _group = group;
    }

    /**
     * 削減率管理を取得
     * @return
     */
    public List<Tbj34CutManagementVO> getTbj34CutManagementVO() {
        return _cut;
    }

    /**
     * 削減率管理を設定
     * @param cut
     */
    public void setTbj34CutManagementVO(List<Tbj34CutManagementVO> cut) {
        _cut = cut;
    }
}

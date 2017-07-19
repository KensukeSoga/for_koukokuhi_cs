package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 費用企画No表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * ・請求業務変更対応(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceCostPlanDispResult extends AbstractServiceResult
{
    /** 費用企画No検索データVO */
    private FindMbj09HiyouVO _costPlanVo = null;
    /** 車種検索データVO */
    private FindMbj05CarVO _carVo = null;
    /** 媒体検索データVO */
    private FindMbj03MediaVO _mediaVo = null;
    /** コードマスタ検索データVO */
    private FindMbj12CodeVO _codeVo = null;

    /* 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD Start */
    /** 媒体(制作)検索データVO */
    private FindMbj49MediaProductionVO _mediaProductionVo = null;
    /** HM担当者マスタ検索データVO */
    private FindMbj48HmUserVO _hmUserVo = null;
    /* 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD End */

    /**
     * 費用企画No検索データVOを設定します
     * @param vo セットする _costPlanVO
     */
    public void setCostPlanVO(FindMbj09HiyouVO vo) {
        _costPlanVo = vo;
    }

    /**
     * 費用企画No検索データVOを取得します
     * @return _costPlanVO
     */
    public FindMbj09HiyouVO getCostPlanVO() {
        return _costPlanVo;
    }

    /**
     * 車種検索データVOを設定します
     * @param vo セットする _carVO
     */
    public void setCarVO(FindMbj05CarVO vo) {
        _carVo = vo;
    }

    /**
     * 車種検索データVOを取得します
     * @return _carVO
     */
    public FindMbj05CarVO getCarVO() {
        return _carVo;
    }

    /**
     * 媒体検索データVOを設定します
     * @param vo セットする _mediaVO
     */
    public void setMediaVO(FindMbj03MediaVO vo) {
        _mediaVo = vo;
    }

    /**
     * 媒体検索データVOを取得します
     * @return _mediaVO
     */
    public FindMbj03MediaVO getMediaVO() {
        return _mediaVo;
    }

    /**
     * コードマスタ検索データVOを設定します
     * @param vo セットする _codeVO
     */
    public void setCodeVO(FindMbj12CodeVO vo) {
        _codeVo = vo;
    }

    /**
     * コードマスタ検索データVOを取得します
     * @return _codeVO
     */
    public FindMbj12CodeVO getCodeVO() {
        return _codeVo;
    }

    /* 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD Start */
    /**
     * 媒体(制作)検索データVOを設定する
     * @param vo FindMbj49MediaProductionVO 媒体(制作)検索データVO
     */
    public void setMediaProduction(FindMbj49MediaProductionVO vo) {
        _mediaProductionVo = vo;
    }

    /**
     * 媒体(制作)検索データVOを取得する
     * @return FindMbj49MediaProductionVO 媒体(制作)検索データVO
     */
    public FindMbj49MediaProductionVO getMediaProduction() {
        return _mediaProductionVo;
    }

    /**
     * HM担当者マスタVOを設定する
     * @param vo FindMbj48HmUserVO HM担当者マスタVO
     */
    public void setHmUserVO(FindMbj48HmUserVO vo) {
        _hmUserVo = vo;
    }

    /**
     * HM担当者マスタVOを取得する
     * @return FindMbj48HmUserVO HM担当者マスタVO
     */
    public FindMbj48HmUserVO getHmUserVO() {
        return _hmUserVo;
    }
    /* 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD End */

}

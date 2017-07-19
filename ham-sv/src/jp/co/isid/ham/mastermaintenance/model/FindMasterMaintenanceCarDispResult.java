package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 車種表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceCarDispResult extends AbstractServiceResult
{
    /** 車種検索データVO */
    private FindMbj05CarVO _carVO = null;

    /** 系列検索データVO */
    private FindMbj04KeiretsuVO _seriesVO = null;

    /** 担当者検索データVO */
    private FindMbj02UserVO _userVO = null;

    /** 車種出力設定検索データVO */
    private FindMbj13CarOutCtrlVO _carOutControlVO = null;

    /**
     * 車種検索データVOを設定します
     * @param vo セットする _carVO
     */
    public void setCarVO(FindMbj05CarVO vo)
    {
        _carVO = vo;
    }

    /**
     * 車種検索データVOを取得します
     * @return _carVO
     */
    public FindMbj05CarVO getCarVO()
    {
        return _carVO;
    }

    /**
     * 系列検索データVOを設定します
     * @param vo セットする _seriesVO
     */
    public void setSeriesVO(FindMbj04KeiretsuVO vo)
    {
        _seriesVO = vo;
    }

    /**
     * 系列検索データVOを取得します
     * @return _seriesVO
     */
    public FindMbj04KeiretsuVO getSeriesVO()
    {
        return _seriesVO;
    }

    /**
     * 担当者検索データVOを設定します
     * @param vo セットする _userVO
     */
    public void setUserVO(FindMbj02UserVO vo)
    {
        _userVO = vo;
    }

    /**
     * 担当者検索データVOを取得します
     * @return _userVO
     */
    public FindMbj02UserVO getUserVO()
    {
        return _userVO;
    }

    /**
     * 車種出力設定検索データVOを設定します
     * @param vo セットする _carOutControlVO
     */
    public void setCarOutControlVO(FindMbj13CarOutCtrlVO vo)
    {
        _carOutControlVO = vo;
    }

    /**
     * 車種出力設定検索データVOを取得します
     * @return _carOutControlVO
     */
    public FindMbj13CarOutCtrlVO getCarOutControlVO()
    {
        return _carOutControlVO;
    }

}

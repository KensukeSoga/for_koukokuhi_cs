package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 媒体表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceMediaDispResult extends AbstractServiceResult
{
    /** 媒体検索データVO */
    private FindMbj03MediaVO _mediaVO = null;

    /** 担当者検索データVO */
    private FindMbj02UserVO _userVO = null;

    /** 媒体出力設定検索データVO */
    private FindMbj14MediaOutCtrlVO _mediaOutControlVO = null;

    /**
     * 媒体検索データVOを設定します
     * @param vo セットする _mediaVO
     */
    public void setMediaVO(FindMbj03MediaVO vo)
    {
        _mediaVO = vo;
    }

    /**
     * 媒体検索データVOを取得します
     * @return _mediaVO
     */
    public FindMbj03MediaVO getMediaVO()
    {
        return _mediaVO;
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
     * 媒体出力設定検索データVOを設定します
     * @param vo セットする _mediaOutControlVO
     */
    public void setMediaOutControlVO(FindMbj14MediaOutCtrlVO vo)
    {
        _mediaOutControlVO = vo;
    }

    /**
     * 媒体出力設定検索データVOを取得します
     * @return _mediaOutControlVO
     */
    public FindMbj14MediaOutCtrlVO getMediaOutControlVO()
    {
        return _mediaOutControlVO;
    }

}

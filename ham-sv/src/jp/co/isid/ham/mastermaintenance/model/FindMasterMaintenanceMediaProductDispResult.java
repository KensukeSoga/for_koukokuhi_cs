package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 媒体・商品紐付表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceMediaProductDispResult extends AbstractServiceResult
{
    /** 媒体・商品紐付検索データVO */
    private FindMbj27MediaProductVO _mediaProductVO = null;

    /** 車種検索データVO */
    private FindMbj05CarVO _carVO = null;

    /** 媒体検索データVO */
    private FindMbj03MediaVO _mediaVO = null;

    /** HC部門検索データVO */
    private FindMbj06HcBumonVO _hCSectionVO = null;

    /** HC商品検索データVO */
    private FindMbj08HcProductVO _hCProductVO = null;

    /**
     * 媒体・商品紐付検索データVOを設定します
     * @param vo セットする _mediaProductVO
     */
    public void setMediaProductVO(FindMbj27MediaProductVO vo)
    {
        _mediaProductVO = vo;
    }

    /**
     * 媒体・商品紐付検索データVOを取得します
     * @return _mediaProductVO
     */
    public FindMbj27MediaProductVO getMediaProductVO()
    {
        return _mediaProductVO;
    }

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
     * HC部門検索データVOを設定します
     * @param vo セットする _hCSectionVO
     */
    public void setHCSectionVO(FindMbj06HcBumonVO vo)
    {
        _hCSectionVO = vo;
    }

    /**
     * HC部門検索データVOを取得します
     * @return _hCSectionVO
     */
    public FindMbj06HcBumonVO getHCSectionVO()
    {
        return _hCSectionVO;
    }

    /**
     * HC商品検索データVOを設定します
     * @param vo セットする _hCProductVO
     */
    public void setHCProductVO(FindMbj08HcProductVO vo)
    {
        _hCProductVO = vo;
    }

    /**
     * HC商品検索データVOを取得します
     * @return _hCProductVO
     */
    public FindMbj08HcProductVO getHCProductVO()
    {
        return _hCProductVO;
    }

}

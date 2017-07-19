package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HC担当者表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceHCUserDispResult extends AbstractServiceResult
{
    /** HC担当者検索データVO */
    private FindMbj07HcUserVO _hCUserVO = null;

    /** HC部門検索データVO */
    private FindMbj06HcBumonVO _hCSectionVO = null;

    /**
     * HC担当者検索データVOを設定します
     * @param vo セットする _hCUserVO
     */
    public void setHCUserVO(FindMbj07HcUserVO vo)
    {
        _hCUserVO = vo;
    }

    /**
     * HC担当者検索データVOを取得します
     * @return _hCUserVO
     */
    public FindMbj07HcUserVO getHCUserVO()
    {
        return _hCUserVO;
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

}

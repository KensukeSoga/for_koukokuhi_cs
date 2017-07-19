package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 請求先グループ表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceDemandGroupDispResult extends AbstractServiceResult
{
    /** 請求先グループ検索データVO */
    private FindMbj26BillGroupVO _demandGroupVO = null;

    /** HC部門検索データVO */
    private FindMbj06HcBumonVO _hCSectionVO = null;

    /**
     * 請求先グループ検索データVOを設定します
     * @param vo セットする _demandGroupVO
     */
    public void setDemandGroupVO(FindMbj26BillGroupVO vo)
    {
        _demandGroupVO = vo;
    }

    /**
     * 請求先グループ検索データVOを取得します
     * @return _demandGroupVO
     */
    public FindMbj26BillGroupVO getDemandGroupVO()
    {
        return _demandGroupVO;
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

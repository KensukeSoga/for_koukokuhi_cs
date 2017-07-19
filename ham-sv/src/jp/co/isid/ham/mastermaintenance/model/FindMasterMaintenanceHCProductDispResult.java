package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HC商品表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceHCProductDispResult extends AbstractServiceResult
{
    /** HC商品スプレッド検索データVO */
    private FindMasterMaintenanceHCProductSpreadVO _hCProductSpreadVO = null;

    /** HC部門検索データVO */
    private FindMbj06HcBumonVO _hCSectionVO = null;

    /** コードマスタ検索データVO */
    private FindMbj12CodeVO _codeVO = null;

    /**
     * HC商品スプレッド検索データVOを設定します
     * @param vo セットする _hCProductSpreadVO
     */
    public void setHCProductSpreadVO(FindMasterMaintenanceHCProductSpreadVO vo)
    {
        _hCProductSpreadVO = vo;
    }

    /**
     * HC商品スプレッド検索データVOを取得します
     * @return _hCProductSpreadVO
     */
    public FindMasterMaintenanceHCProductSpreadVO getHCProductSpreadVO()
    {
        return _hCProductSpreadVO;
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
     * コードマスタ検索データVOを設定します
     * @param vo セットする _codeVO
     */
    public void setCodeVO(FindMbj12CodeVO vo)
    {
        _codeVO = vo;
    }

    /**
     * コードマスタ検索データVOを取得します
     * @return _codeVO
     */
    public FindMbj12CodeVO getCodeVO()
    {
        return _codeVO;
    }

}

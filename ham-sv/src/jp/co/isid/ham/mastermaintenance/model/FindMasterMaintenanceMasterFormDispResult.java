package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * MasterForm表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/04 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceMasterFormDispResult extends AbstractServiceResult
{
    /** MasterForm検索データVO */
    FindMasterMaintenanceMasterFormVO _masterFormVO = null;

    /** セキュリティ検索データVO */
    private FindMbj42SecurityVO _securityVO = null;

    /** セキュリティベース検索データVO */
    private FindMbj44SecurityBaseVO _securityBaseVO = null;

    /**
     * MasterForm検索データVOを設定します
     * @param vo セットする _masterFormVO
     */
    public void setMasterFormVO(FindMasterMaintenanceMasterFormVO vo)
    {
        _masterFormVO = vo;
    }

    /**
     * MasterForm検索データVOを取得します
     * @return _masterFormVO
     */
    public FindMasterMaintenanceMasterFormVO getMasterFormVO()
    {
        return _masterFormVO;
    }

    /**
     * セキュリティ検索データVOを設定します
     * @param vo セットする _securityVO
     */
    public void setSecurityVO(FindMbj42SecurityVO vo)
    {
        _securityVO = vo;
    }

    /**
     * セキュリティ検索データVOを取得します
     * @return _securityVO
     */
    public FindMbj42SecurityVO getSecurityVO()
    {
        return _securityVO;
    }

    /**
     * セキュリティベース検索データVOを設定します
     * @param vo セットする _securityBaseVO
     */
    public void setSecurityBaseVO(FindMbj44SecurityBaseVO vo)
    {
        _securityBaseVO = vo;
    }

    /**
     * セキュリティベース検索データVOを取得します
     * @return _securityBaseVO
     */
    public FindMbj44SecurityBaseVO getSecurityBaseVO()
    {
        return _securityBaseVO;
    }

}

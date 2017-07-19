package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 権限表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/10 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceAuthorityDispResult extends AbstractServiceResult
{
    /** 車種権限スプレッド検索データVO */
    private FindMasterMaintenanceCarAuthoritySpreadVO _carAuthoritySpreadVO = null;

    /** 媒体権限スプレッド検索データVO */
    private FindMasterMaintenanceMediaAuthoritySpreadVO _mediaAuthoritySpreadVO = null;

    /** セキュリティスプレッド検索データVO */
    private FindMasterMaintenanceSecuritySpreadVO _securitySpreadVO = null;

    /** セキュリティベース検索データVO */
    private FindMbj44SecurityBaseVO _securityBaseVO = null;

    /** 担当者検索データVO */
    private FindMbj02UserVO _userVO = null;

    /**
     * 車種権限スプレッド検索データVOを設定します
     * @param vo セットする _carAuthoritySpreadVO
     */
    public void setCarAuthoritySpreadVO(FindMasterMaintenanceCarAuthoritySpreadVO vo)
    {
        _carAuthoritySpreadVO = vo;
    }

    /**
     * 車種権限スプレッド検索データVOを取得します
     * @return _carAuthoritySpreadVO
     */
    public FindMasterMaintenanceCarAuthoritySpreadVO getCarAuthoritySpreadVO()
    {
        return _carAuthoritySpreadVO;
    }

    /**
     * 媒体権限スプレッド検索データVOを設定します
     * @param vo セットする _mediaAuthoritySpreadVO
     */
    public void setMediaAuthoritySpreadVO(FindMasterMaintenanceMediaAuthoritySpreadVO vo)
    {
        _mediaAuthoritySpreadVO = vo;
    }

    /**
     * 媒体権限スプレッド検索データVOを取得します
     * @return _mediaAuthoritySpreadVO
     */
    public FindMasterMaintenanceMediaAuthoritySpreadVO getMediaAuthoritySpreadVO()
    {
        return _mediaAuthoritySpreadVO;
    }

    /**
     * セキュリティスプレッド検索データVOを設定します
     * @param vo セットする _securitySpreadVO
     */
    public void setSecuritySpreadVO(FindMasterMaintenanceSecuritySpreadVO vo)
    {
        _securitySpreadVO = vo;
    }

    /**
     * セキュリティスプレッド検索データVOを取得します
     * @return _securitySpreadVO
     */
    public FindMasterMaintenanceSecuritySpreadVO getSecuritySpreadVO()
    {
        return _securitySpreadVO;
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

}

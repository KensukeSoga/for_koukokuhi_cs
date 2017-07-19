package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 担当者表示登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * ・HDX対応(2016/02/29 K.Oki)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceUserDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 担当者登録データVO */
    private RegistMbj02UserVO _userVO = null;

    /** 車種権限登録データVO */
    private RegistMbj11CarSecVO _carAuthorityVO = null;

    /** 媒体権限登録データVO */
    private RegistMbj10MediaSecVO _mediaAuthorityVO = null;

    /** 機能制御登録データVO */
    private RegistMbj33FunctionControlVO _functionControlVO = null;

    /** セキュリティ登録データVO */
    private RegistMbj42SecurityVO _securityVO = null;

    /** アラート表示制御登録データVO */
    private RegistMbj41AlertDispControlVO _alertDispControlVO = null;

    /* 2016/02/29 HDX対応 HLC K.Oki ADD Start */
    /** 車種担当者(素材)登録データVO */
    private RegistMbj52SzTntUserVO _SzTntUserVO = null;
    /* 2016/02/29 HDX対応 HLC K.Oki ADD End */

    /**
     * デフォルトコンストラクタ
     */
    public RegistMasterMaintenanceUserDispVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceUserDispVO();
    }

    /**
     * 担当者登録データVOを設定します
     * @param vo セットする _userVO
     */
    public void setUserVO(RegistMbj02UserVO vo)
    {
        _userVO = vo;
    }

    /**
     * 担当者登録データVOを取得します
     * @return _userVO
     */
    public RegistMbj02UserVO getUserVO()
    {
        return _userVO;
    }

    /**
     * 車種権限登録データVOを設定します
     * @param vo セットする _carAuthorityVO
     */
    public void setCarAuthorityVO(RegistMbj11CarSecVO vo)
    {
        _carAuthorityVO = vo;
    }

    /**
     * 車種権限登録データVOを取得します
     * @return _carAuthorityVO
     */
    public RegistMbj11CarSecVO getCarAuthorityVO()
    {
        return _carAuthorityVO;
    }

    /**
     * 媒体権限登録データVOを設定します
     * @param vo セットする _mediaAuthorityVO
     */
    public void setMediaAuthorityVO(RegistMbj10MediaSecVO vo)
    {
        _mediaAuthorityVO = vo;
    }

    /**
     * 媒体権限登録データVOを取得します
     * @return _mediaAuthorityVO
     */
    public RegistMbj10MediaSecVO getMediaAuthorityVO()
    {
        return _mediaAuthorityVO;
    }

    /**
     * 機能制御登録データVOを設定します
     * @param vo セットする _functionControlVO
     */
    public void setFunctionControlVO(RegistMbj33FunctionControlVO vo)
    {
        _functionControlVO = vo;
    }

    /**
     * 機能制御登録データVOを取得します
     * @return _functionControlVO
     */
    public RegistMbj33FunctionControlVO getFunctionControlVO()
    {
        return _functionControlVO;
    }

    /**
     * セキュリティ登録データVOを設定します
     * @param vo セットする _securityVO
     */
    public void setSecurityVO(RegistMbj42SecurityVO vo)
    {
        _securityVO = vo;
    }

    /**
     * セキュリティ登録データVOを取得します
     * @return _securityVO
     */
    public RegistMbj42SecurityVO getSecurityVO()
    {
        return _securityVO;
    }

    /**
     * アラート表示制御登録データVOを設定します
     * @param vo セットする _alartDispControlVO
     */
    public void setAlertDispControlVO(RegistMbj41AlertDispControlVO vo)
    {
        _alertDispControlVO = vo;
    }

    /**
     * アラート表示制御登録データVOを取得します
     * @return _alartDispControlVO
     */
    public RegistMbj41AlertDispControlVO getAlertDispControlVO()
    {
        return _alertDispControlVO;
    }

    /* 2016/02/29 HDX対応 HLC K.Oki ADD Start */
    /**
     * 車種担当者(素材)登録データVOを設定します
     * @param vo セットする _SzTntUserVO
     */
    public void setSzTntUserVO(RegistMbj52SzTntUserVO vo)
    {
        _SzTntUserVO = vo;
    }

    /**
     * 車種担当者(素材)登録データVOを取得します
     * @return _SzTntUserVO
     */
    public RegistMbj52SzTntUserVO getSzTntUserVO()
    {
        return _SzTntUserVO;
    }
    /* 2016/02/29 HDX対応 HLC K.Oki ADD End */

}

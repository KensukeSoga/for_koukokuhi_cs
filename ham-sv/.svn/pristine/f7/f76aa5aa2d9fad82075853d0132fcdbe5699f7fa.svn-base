package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 権限表示登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/10 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceAuthorityDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 車種権限登録データVO */
    private RegistMbj11CarSecVO _carAuthorityVO = null;

    /** 媒体権限登録データVO */
    private RegistMbj10MediaSecVO _mediaAuthorityVO = null;

    /** セキュリティ登録データVO */
    private RegistMbj42SecurityVO _securityVO = null;

    /**
     * デフォルトコンストラクタ
     */
    public RegistMasterMaintenanceAuthorityDispVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceAuthorityDispVO();
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

}

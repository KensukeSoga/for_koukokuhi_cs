package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 媒体表示登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceMediaDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 媒体登録データVO */
    private RegistMbj03MediaVO _mediaVO = null;

    /** 媒体権限登録データVO */
    private RegistMbj10MediaSecVO _mediaAuthorityVO = null;

    /** 媒体出力設定登録データVO */
    private RegistMbj14MediaOutCtrlVO _mediaOutControlVO = null;

    /** 費用企画No登録データVO */
    private RegistMbj09HiyouVO _costPlanVO = null;

    /** 媒体・商品紐付登録データVO */
    private RegistMbj27MediaProductVO _mediaProductVO = null;

    /**
     * デフォルトコンストラクタ
     */
    public RegistMasterMaintenanceMediaDispVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceMediaDispVO();
    }

    /**
     * 媒体登録データVOを設定します
     * @param vo セットする _mediaVO
     */
    public void setMediaVO(RegistMbj03MediaVO vo)
    {
        _mediaVO = vo;
    }

    /**
     * 媒体登録データVOを取得します
     * @return _mediaVO
     */
    public RegistMbj03MediaVO getMediaVO()
    {
        return _mediaVO;
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
     * 媒体出力設定登録データVOを設定します
     * @param vo セットする _mediaOutControlVO
     */
    public void setMediaOutControlVO(RegistMbj14MediaOutCtrlVO vo)
    {
        _mediaOutControlVO = vo;
    }

    /**
     * 媒体出力設定登録データVOを取得します
     * @return _mediaOutControlVO
     */
    public RegistMbj14MediaOutCtrlVO getMediaOutControlVO()
    {
        return _mediaOutControlVO;
    }

    /**
     * 費用企画No登録データVOを設定します
     * @param vo セットする _costPlanVO
     */
    public void setCostPlanVO(RegistMbj09HiyouVO vo)
    {
        _costPlanVO = vo;
    }

    /**
     * 費用企画No登録データVOを取得します
     * @return _costPlanVO
     */
    public RegistMbj09HiyouVO getCostPlanVO()
    {
        return _costPlanVO;
    }

    /**
     * 媒体・商品紐付登録データVOを設定します
     * @param vo セットする _mediaProductVO
     */
    public void setMediaProductVO(RegistMbj27MediaProductVO vo)
    {
        _mediaProductVO = vo;
    }

    /**
     * 媒体・商品紐付登録データVOを取得します
     * @return _mediaProductVO
     */
    public RegistMbj27MediaProductVO getMediaProductVO()
    {
        return _mediaProductVO;
    }

}

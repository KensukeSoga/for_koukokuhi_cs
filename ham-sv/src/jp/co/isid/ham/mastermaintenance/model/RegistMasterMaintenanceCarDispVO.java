package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 車種表示登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceCarDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 車種登録データVO */
    private RegistMbj05CarVO _carVO = null;

    /** 車種担当登録データVO */
    private RegistMbj23CarTantoVO _carUserVO = null;

    /** 車種権限登録データVO */
    private RegistMbj11CarSecVO _carAuthorityVO = null;

    /** 車種カテゴリ紐付登録データVO */
    private RegistMbj22CategoryContentVO _carCategoryContentVO = null;

    /** 車種出力設定登録データVO */
    private RegistMbj13CarOutCtrlVO _carOutControlVO = null;

    /** 費用企画No登録データVO */
    private RegistMbj09HiyouVO _costPlanVO = null;

    /** 媒体・商品紐付登録データVO */
    private RegistMbj27MediaProductVO _mediaProductVO = null;

    /** アラート表示制御登録データVO */
    private RegistMbj41AlertDispControlVO _alertDispControlVO = null;

    /** 入力担当登録データVO */
    private RegistMbj30InputTntVO _inputUserVO = null;

    /**
     * デフォルトコンストラクタ
     */
    public RegistMasterMaintenanceCarDispVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceCarDispVO();
    }

    /**
     * 車種登録データVOを設定します
     * @param vo セットする _carVO
     */
    public void setCarVO(RegistMbj05CarVO vo)
    {
        _carVO = vo;
    }

    /**
     * 車種登録データVOを取得します
     * @return _carVO
     */
    public RegistMbj05CarVO getCarVO()
    {
        return _carVO;
    }

    /**
     * 車種担当登録データVOを設定します
     * @param vo セットする _carUserVO
     */
    public void setCarUserVO(RegistMbj23CarTantoVO vo)
    {
        _carUserVO = vo;
    }

    /**
     * 車種担当登録データVOを取得します
     * @return _carUserVO
     */
    public RegistMbj23CarTantoVO getCarUserVO()
    {
        return _carUserVO;
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
     * 車種カテゴリ紐付登録データVOを設定します
     * @param vo セットする _carCategoryContentVO
     */
    public void setCarCategoryContentVO(RegistMbj22CategoryContentVO vo)
    {
        _carCategoryContentVO = vo;
    }

    /**
     * 車種カテゴリ紐付登録データVOを取得します
     * @return _carCategoryContentVO
     */
    public RegistMbj22CategoryContentVO getCarCategoryContentVO()
    {
        return _carCategoryContentVO;
    }

    /**
     * 車種出力設定登録データVOを設定します
     * @param vo セットする _carOutControlVO
     */
    public void setCarOutControlVO(RegistMbj13CarOutCtrlVO vo)
    {
        _carOutControlVO = vo;
    }

    /**
     * 車種出力設定登録データVOを取得します
     * @return _carOutControlVO
     */
    public RegistMbj13CarOutCtrlVO getCarOutControlVO()
    {
        return _carOutControlVO;
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

    /**
     * 入力担当登録データVOを設定します
     * @param vo セットする _inputUserVO
     */
    public void setInputUserVO(RegistMbj30InputTntVO vo)
    {
        _inputUserVO = vo;
    }

    /**
     * 入力担当登録データVOを取得します
     * @return _inputUserVO
     */
    public RegistMbj30InputTntVO getInputUserVO()
    {
        return _inputUserVO;
    }

}

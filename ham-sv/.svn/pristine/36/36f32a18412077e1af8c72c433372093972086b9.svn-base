package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * インフォメーション表示登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceInformationDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** インフォメーション登録データVO */
    private RegistMbj31InformationVO _informationVO = null;

    /**
     * デフォルトコンストラクタ
     */
    public RegistMasterMaintenanceInformationDispVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceInformationDispVO();
    }

    /**
     * インフォメーション登録データVOを設定します
     * @param vo セットする _informationVO
     */
    public void setInformationVO(RegistMbj31InformationVO vo)
    {
        _informationVO = vo;
    }

    /**
     * インフォメーション登録データVOを取得します
     * @return _informationVO
     */
    public RegistMbj31InformationVO getInformationVO()
    {
        return _informationVO;
    }

}

package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 費用企画No表示登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceCostPlanDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 費用企画No登録データVO */
    private RegistMbj09HiyouVO _costPlanVO = null;

    /**
     * デフォルトコンストラクタ
     */
    public RegistMasterMaintenanceCostPlanDispVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceCostPlanDispVO();
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

}

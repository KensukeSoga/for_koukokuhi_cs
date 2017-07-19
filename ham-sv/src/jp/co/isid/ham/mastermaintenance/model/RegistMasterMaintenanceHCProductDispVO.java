package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HC商品表示登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceHCProductDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** HC商品登録データVO */
    private RegistMbj08HcProductVO _hCProductVO = null;

    /**
     * デフォルトコンストラクタ
     */
    public RegistMasterMaintenanceHCProductDispVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceHCProductDispVO();
    }

    /**
     * HC商品登録データVOを設定します
     * @param vo セットする _hCProductVO
     */
    public void setHCProductVO(RegistMbj08HcProductVO vo)
    {
        _hCProductVO = vo;
    }

    /**
     * HC商品登録データVOを取得します
     * @return _hCProductVO
     */
    public RegistMbj08HcProductVO getHCProductVO()
    {
        return _hCProductVO;
    }

}

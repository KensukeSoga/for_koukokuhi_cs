package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 車種カテゴリ表示登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceCarCategoryDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 車種カテゴリ登録データVO */
    private RegistMbj20CarCategoryVO _carCategoryVO = null;

    /** 車種カテゴリ紐付登録データVO */
    private RegistMbj22CategoryContentVO _carCategoryContentVO = null;

    /**
     * デフォルトコンストラクタ
     */
    public RegistMasterMaintenanceCarCategoryDispVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceCarCategoryDispVO();
    }

    /**
     * 車種カテゴリ登録データVOを設定します
     * @param vo セットする _carCategoryVO
     */
    public void setCarCategoryVO(RegistMbj20CarCategoryVO vo)
    {
        _carCategoryVO = vo;
    }

    /**
     * 車種カテゴリ登録データVOを取得します
     * @return _carCategoryVO
     */
    public RegistMbj20CarCategoryVO getCarCategoryVO()
    {
        return _carCategoryVO;
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

}

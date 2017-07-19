package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;


/**
 * <P>
 * 車種担当(素材)表示登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/02/23 K.Oki)<BR>
 * </P>
 * @author HLC K.Oki
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceCarUserSozaiDispVO extends AbstractModel
{
    private static final long serialVersionUID = 1L;

    /** 車種担当(素材)登録データVO */
    private RegistMbj52SzTntUserVO _carUserSozaiVO = null;

    /**
     * デフォルトコンストラクタ
     */
    public RegistMasterMaintenanceCarUserSozaiDispVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceCarUserSozaiDispVO();
    }

    /**
     * 車種担当(素材)登録データVOを設定します
     * @param vo セットする _carUserVO
     */
    public void setCarUserSozaiVO(RegistMbj52SzTntUserVO vo)
    {
        _carUserSozaiVO = vo;
    }

    /**
     * 車種担当(素材)登録データVOを取得します
     * @return _carUserVO
     */
    public RegistMbj52SzTntUserVO getCarUserSozaiVO()
    {
        return _carUserSozaiVO;
    }
}

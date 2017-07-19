package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 設定局表示登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceEstablishmentOfficeDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 設定局登録データVO */
    private RegistMbj29SetteiKykVO _establishmentOfficeVO = null;

    /**
     * デフォルトコンストラクタ
     */
    public RegistMasterMaintenanceEstablishmentOfficeDispVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceEstablishmentOfficeDispVO();
    }

    /**
     * 設定局登録データVOを設定します
     * @param vo セットする _establishmentOfficeVO
     */
    public void setEstablishmentOfficeVO(RegistMbj29SetteiKykVO vo)
    {
        _establishmentOfficeVO = vo;
    }

    /**
     * 設定局登録データVOを取得します
     * @return _establishmentOfficeVO
     */
    public RegistMbj29SetteiKykVO getEstablishmentOfficeVO()
    {
        return _establishmentOfficeVO;
    }

}

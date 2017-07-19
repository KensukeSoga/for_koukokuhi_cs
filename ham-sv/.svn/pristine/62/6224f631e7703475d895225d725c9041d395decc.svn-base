package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 車種担当表示登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceCarUserDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 車種担当登録データVO */
    private RegistMbj23CarTantoVO _carUserVO = null;

    /**
     * デフォルトコンストラクタ
     */
    public RegistMasterMaintenanceCarUserDispVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceCarUserDispVO();
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

}

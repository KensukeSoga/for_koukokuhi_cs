package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * メール配信表示登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/02/07 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceAlertMailAddressDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** メール配信登録データVO */
    private RegistMbj40AlertMailAddressVO _alertMailAddressVO = null;

    /**
     * デフォルトコンストラクタ
     */
    public RegistMasterMaintenanceAlertMailAddressDispVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceAlertMailAddressDispVO();
    }

    /**
     * メール配信登録データVOを設定します
     * @param vo セットする _alartMailAddressVO
     */
    public void setAlertMailAddressVO(RegistMbj40AlertMailAddressVO vo)
    {
        _alertMailAddressVO = vo;
    }

    /**
     * メール配信登録データVOを取得します
     * @return _alartMailAddressVO
     */
    public RegistMbj40AlertMailAddressVO getAlertMailAddressVO()
    {
        return _alertMailAddressVO;
    }

}

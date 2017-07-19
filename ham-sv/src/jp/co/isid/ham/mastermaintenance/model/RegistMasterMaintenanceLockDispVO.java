package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 過去ロック表示登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/04 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceLockDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 過去ロック登録データVO */
    private RegistMbj01SysStsVO _lockVO = null;

    /**
     * デフォルトコンストラクタ
     */
    public RegistMasterMaintenanceLockDispVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceLockDispVO();
    }

    /**
     * 過去ロック登録データVOを設定します
     * @param vo セットする _lockVO
     */
    public void setLockVO(RegistMbj01SysStsVO vo)
    {
        _lockVO = vo;
    }

    /**
     * 過去ロック登録データVOを取得します
     * @return _lockVO
     */
    public RegistMbj01SysStsVO getLockVO()
    {
        return _lockVO;
    }

}

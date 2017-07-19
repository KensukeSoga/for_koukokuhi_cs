package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HM担当者表示登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceHMUserDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** HM担当者登録データVO */
    private RegistMbj48HmUserVO _hmUserVO = null;

    /**
     * デフォルトコンストラクタ
     */
    public RegistMasterMaintenanceHMUserDispVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new RegistMasterMaintenanceHMUserDispVO();
    }

    /**
     * HM担当者登録データVOを設定します
     * @param vo RegistMbj48HmUserVO HM担当者登録データVO
     */
    public void setHMUserVO(RegistMbj48HmUserVO vo) {
        _hmUserVO = vo;
    }

    /**
     * HM担当者登録データVOを取得します
     * @return RegistMbj48HmUserVO HM担当者登録データVO
     */
    public RegistMbj48HmUserVO getHMUserVO() {
        return _hmUserVO;
    }

}

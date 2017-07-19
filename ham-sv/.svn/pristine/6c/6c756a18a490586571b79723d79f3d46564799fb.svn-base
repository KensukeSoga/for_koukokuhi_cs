package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 入力担当表示登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceInputUserDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 入力担当登録データVO */
    private RegistMbj30InputTntVO _inputUserVO = null;

    /**
     * デフォルトコンストラクタ
     */
    public RegistMasterMaintenanceInputUserDispVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceInputUserDispVO();
    }

    /**
     * 入力担当登録データVOを設定します
     * @param vo セットする _inputUserVO
     */
    public void setInputUserVO(RegistMbj30InputTntVO vo)
    {
        _inputUserVO = vo;
    }

    /**
     * 入力担当登録データVOを取得します
     * @return _inputUserVO
     */
    public RegistMbj30InputTntVO getInputUserVO()
    {
        return _inputUserVO;
    }

}

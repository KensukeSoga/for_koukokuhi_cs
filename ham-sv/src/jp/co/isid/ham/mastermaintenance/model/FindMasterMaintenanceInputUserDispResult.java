package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * ���͒S���\�����Result
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/13 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceInputUserDispResult extends AbstractServiceResult
{
    /** ���͒S�������f�[�^VO */
    private FindMbj30InputTntVO _inputUserVO = null;

    /** �Ԏ팟���f�[�^VO */
    private FindMbj05CarVO _carVO = null;

    /**
     * ���͒S�������f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _inputUserVO
     */
    public void setInputUserVO(FindMbj30InputTntVO vo)
    {
        _inputUserVO = vo;
    }

    /**
     * ���͒S�������f�[�^VO���擾���܂�
     * @return _inputUserVO
     */
    public FindMbj30InputTntVO getInputUserVO()
    {
        return _inputUserVO;
    }

    /**
     * �Ԏ팟���f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _carVO
     */
    public void setCarVO(FindMbj05CarVO vo)
    {
        _carVO = vo;
    }

    /**
     * �Ԏ팟���f�[�^VO���擾���܂�
     * @return _carVO
     */
    public FindMbj05CarVO getCarVO()
    {
        return _carVO;
    }

}

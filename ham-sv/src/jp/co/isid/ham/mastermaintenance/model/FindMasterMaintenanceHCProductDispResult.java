package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HC���i�\�����Result
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/13 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceHCProductDispResult extends AbstractServiceResult
{
    /** HC���i�X�v���b�h�����f�[�^VO */
    private FindMasterMaintenanceHCProductSpreadVO _hCProductSpreadVO = null;

    /** HC���匟���f�[�^VO */
    private FindMbj06HcBumonVO _hCSectionVO = null;

    /** �R�[�h�}�X�^�����f�[�^VO */
    private FindMbj12CodeVO _codeVO = null;

    /**
     * HC���i�X�v���b�h�����f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _hCProductSpreadVO
     */
    public void setHCProductSpreadVO(FindMasterMaintenanceHCProductSpreadVO vo)
    {
        _hCProductSpreadVO = vo;
    }

    /**
     * HC���i�X�v���b�h�����f�[�^VO���擾���܂�
     * @return _hCProductSpreadVO
     */
    public FindMasterMaintenanceHCProductSpreadVO getHCProductSpreadVO()
    {
        return _hCProductSpreadVO;
    }

    /**
     * HC���匟���f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _hCSectionVO
     */
    public void setHCSectionVO(FindMbj06HcBumonVO vo)
    {
        _hCSectionVO = vo;
    }

    /**
     * HC���匟���f�[�^VO���擾���܂�
     * @return _hCSectionVO
     */
    public FindMbj06HcBumonVO getHCSectionVO()
    {
        return _hCSectionVO;
    }

    /**
     * �R�[�h�}�X�^�����f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _codeVO
     */
    public void setCodeVO(FindMbj12CodeVO vo)
    {
        _codeVO = vo;
    }

    /**
     * �R�[�h�}�X�^�����f�[�^VO���擾���܂�
     * @return _codeVO
     */
    public FindMbj12CodeVO getCodeVO()
    {
        return _codeVO;
    }

}

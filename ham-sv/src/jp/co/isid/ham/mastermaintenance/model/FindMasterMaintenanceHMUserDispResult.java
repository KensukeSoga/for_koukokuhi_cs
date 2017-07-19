package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HM�S���ҕ\�����Result
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceHMUserDispResult extends AbstractServiceResult
{
    /** HM�S���Ҍ����f�[�^VO */
    private FindMbj48HmUserVO _hmUserVo = null;
    /** �R�[�h�}�X�^�����f�[�^VO */
    private FindMbj12CodeVO _codeVo = null;

    /**
     * HM�S���Ҍ����f�[�^VO��ݒ肷��
     * @param vo FindMbj48HmUserVO HM�S���Ҍ����f�[�^VO
     */
    public void setHMUserVO(FindMbj48HmUserVO vo) {
        _hmUserVo = vo;
    }

    /**
     * HM�S���Ҍ����f�[�^VO���擾����
     * @return FindMbj48HmUserVO HM�S���Ҍ����f�[�^VO
     */
    public FindMbj48HmUserVO getHMUserVO() {
        return _hmUserVo;
    }

    /**
     * �R�[�h�}�X�^�����f�[�^VO��ݒ肷��
     * @param vo FindMbj12CodeVO �R�[�h�}�X�^�����f�[�^VO
     */
    public void setCodeVO(FindMbj12CodeVO vo) {
        _codeVo = vo;
    }

    /**
     * �R�[�h�}�X�^�����f�[�^VO
     * @return FindMbj12CodeVO �R�[�h�}�X�^�����f�[�^VO
     */
    public FindMbj12CodeVO getCodeVO() {
        return _codeVo;
    }

}

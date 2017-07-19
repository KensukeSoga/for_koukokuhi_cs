package jp.co.isid.ham.common.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * �N���������s����
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/12 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class StartUpResult extends AbstractServiceResult {

    /**
     * ���[�U�[�}�X�^VO���X�g
     */
    private List<Mbj02UserVO> _mbj02vo;

    /**
     * �R�[�h�}�X�^VO���X�g
     */
    private List<Mbj12CodeVO> _mbj12vo;

    /**
     * �V�X�e���g�p��VO���X�g
     */
    private List<Mbj01SysStsVO> _mbj01vo;

    /**
     * �VHAM����VIEW(�l���)VO���X�g
     */
    private List<Vbj01AccUserVO> _vbj01vo;

    /**
     * �Ǘ��e�[�u��VO���X�g
     */
    private List<Tbj35KnrVO> _tbj35vo;

    /**
     * �o���g�D�W�J�e�[�u��
     */
    private List<RepaVbjaMeu07SikKrSprdVO> _sikKrSprdVo;


    /**
     * ���[�U�[�}�X�^VO���X�g���擾���܂�
     * @return ���[�U�[�}�X�^VO���X�g
     */
    public List<Mbj02UserVO> getUserList() {
        return _mbj02vo;
    }

    /**
     * ���[�U�[�}�X�^VO���X�g��ݒ肵�܂�
     * @param mbj02vo ���[�U�[�}�X�^VO���X�g
     */
    public void setUserList(List<Mbj02UserVO> mbj02vo) {
        _mbj02vo = mbj02vo;
    }

    /**
     * �R�[�h�}�X�^VO���X�g���擾���܂�
     * @return  �R�[�h�}�X�^VO���X�g
     */
    public List<Mbj12CodeVO> getCodeList() {
        return _mbj12vo;
    }

    /**
     * �R�[�h�}�X�^VO���X�g��ݒ肵�܂�
     * @param mbj12vo  �R�[�h�}�X�^VO���X�g
     */
    public void setCodeList(List<Mbj12CodeVO> mbj12vo) {
        _mbj12vo = mbj12vo;
    }

    /**
     * �V�X�e���g�p��VO���X�g���擾���܂�
     * @return �V�X�e���g�p��VO���X�g
     */
    public List<Mbj01SysStsVO> getSysStsList() {
        return _mbj01vo;
    }

    /**
     * �V�X�e���g�p��VO���X�g��ݒ肵�܂�
     * @param mbj01vo �V�X�e���g�p��VO���X�g
     */
    public void setSysStsList(List<Mbj01SysStsVO> mbj01vo) {
        _mbj01vo = mbj01vo;
    }

    /**
     * �VHAM����VIEW(�l���)VO���X�g���擾���܂�
     * @return �VHAM����VIEW(�l���)
     */
    public List<Vbj01AccUserVO> getAccUserList() {
        return _vbj01vo;
    }

    /**
     * �VHAM����VIEW(�l���)VO���X�g��ݒ肵�܂�
     * @param vbj01vo �VHAM����VIEW(�l���)
     */
    public void setAccUserList(List<Vbj01AccUserVO> vbj01vo) {
        _vbj01vo = vbj01vo;
    }

    /**
     * �Ǘ��e�[�u��VO���X�g���擾���܂�
     * @return �Ǘ��e�[�u��
     */
    public List<Tbj35KnrVO> getKnrList() {
        return _tbj35vo;
    }

    /**
     * �Ǘ��e�[�u��VO���X�g��ݒ肵�܂�
     * @param tbj35vo �Ǘ��e�[�u��
     */
    public void setKnrList(List<Tbj35KnrVO> tbj35vo) {
        _tbj35vo = tbj35vo;
    }

    /**
     * �o���g�D�W�J�e�[�u�����擾���܂�
     * @return �o���g�D�W�J�e�[�u��
     */
    public List<RepaVbjaMeu07SikKrSprdVO>  getSikKrSprd() {
        return _sikKrSprdVo;
    }

    /**
     * �o���g�D�W�J�e�[�u����ݒ肵�܂�
     * @param sikKrSprdVo �o���g�D�W�J�e�[�u��
     */
    public void setSikKrSprd(List<RepaVbjaMeu07SikKrSprdVO> sikKrSprdVo) {
        _sikKrSprdVo = sikKrSprdVo;
    }
}
